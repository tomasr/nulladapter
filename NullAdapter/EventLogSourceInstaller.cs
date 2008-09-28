
//
// EventLogSourceInstaller.cs
//
// Author:
//    Tomas Restrepo (tomasr@mvps.org)
//

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;

namespace Winterdom.BizTalk.Adapters {
   /// <summary>
   /// Installer class that creates the event log source we use.
   /// </summary>
   /// <remarks>
   /// You can use installutil.exe on this
   /// assembly to register the event source prior to using
   /// the adapter
   /// </remarks>
   [RunInstaller(true)]
   public class EventLogSourceInstaller : Installer {
      public EventLogSourceInstaller() {
      }

      public override void Install(IDictionary stateSaver) {
         base.Install(stateSaver);
         LogHelper.CreateEventSource();
      }

      public override void Rollback(System.Collections.IDictionary savedState) {
         base.Rollback(savedState);
         LogHelper.DeleteEventSource();
      }

   } // class EventLogSourceInstaller

} // namespace Winterdom.BizTalk.Adapters
