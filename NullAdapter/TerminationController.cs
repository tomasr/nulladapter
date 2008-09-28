
//
// TerminationController.cs
//
// Author:
//    Tomas Restrepo (tomasr@mvps.org)
//

using System;
using System.Threading;

namespace Winterdom.BizTalk.Adapters {
   /// <summary>
   /// Class used to ensure the adapter
   /// is terminated correctly, waiting for existing
   /// operations to complete.
   /// </summary>
   internal class TerminationController {
      private AutoResetEvent _event = new AutoResetEvent(true);
      private int _opCount;
      private bool _terminating;

      /// <summary>
      /// Increase the reference count because a
      /// new operation is in progress
      /// </summary>
      /// <exception cref="InvalidOperationException">If the adapter is terminating</exception>
      public void Enter() {
         if ( _terminating ) {
            throw new InvalidOperationException("Adapter is terminating...");
         }

         _event.Reset();
         Interlocked.Increment(ref _opCount);
      }

      /// <summary>
      /// Decrement the reference count because
      /// a operation is terminating
      /// </summary>
      public void Leave() {
         if ( Interlocked.Decrement(ref _opCount) == 0 ) {
            _event.Set();
         }
      }

      /// <summary>
      /// Terminate the adapter. We don't allow new 
      /// operations after this point
      /// </summary>
      public void Terminate() {
         _terminating = true;
         _event.WaitOne();
      }

   } // class TerminationController

} // namespace Winterdom.BizTalk.Adapters
