
//
// LogHelper.cs
//
// Author:
//    Tomas Restrepo (tomasr@mvps.org)
//

using System;
using System.Diagnostics;


namespace Winterdom.BizTalk.Adapters {
   /// <summary>
   /// Helper class to log things
   /// to the event log.
   /// </summary>
   internal class LogHelper {
      const string LOGSOURCE = "/dev/null Adapter";
      const int MSGDISCAREDID = 1010;

      /// <summary>
      /// Log a message discarded event to the event
      /// log
      /// </summary>
      /// <param name="msgID">Message ID</param>
      /// <param name="interchangeID">Interchange ID</param>
      public static void LogMessage(Guid msgID, string interchangeID) {
         string entry =
               "The following message has been discarded: " +
               "\r\n\r\n" +
               "MessageID: {0}\r\n" +
               "InterchangeID: {0}\r\n";
         entry = string.Format(entry, msgID, interchangeID);

         EventLog.WriteEntry(
                     LOGSOURCE, entry,
                     EventLogEntryType.Information
                  );
      }

      /// <summary>
      /// Creates the event source
      /// </summary>
      public static void CreateEventSource() {
         if ( !EventLog.SourceExists(LOGSOURCE) ) {
            EventLog.CreateEventSource(LOGSOURCE, "Application");
         }
      }

      /// <summary>
      /// Deletes the event source
      /// </summary>
      public static void DeleteEventSource() {
         if ( EventLog.SourceExists(LOGSOURCE) ) {
            EventLog.DeleteEventSource(LOGSOURCE);
         }
      }

   } // class LogHelper

} // namespace Winterdom.BizTalk.Adapters
