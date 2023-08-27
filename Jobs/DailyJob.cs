using DOM.Transcriptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DOM.Jobs
{
    /// <summary>
    /// Clase que representa un trabajo diario
    /// </summary>
    public class DailyJob
    {

        #region Constructors

        public DailyJob ()
        {
            Transcriptions = new List<Transcription>();
        }

        #endregion

        #region Public Properties

        public List<Transcription> Transcriptions { private set; get; }

        #endregion 

        #region Public Methods

        public void AddTranscription(string path, int userId)
        {
            Transcriptions.Add(new Transcription(path, userId));
        }

        public void DeleteTranscriptionByReportId(Guid reportId)
        {
            Transcription transcriptionToDelete = Transcriptions.FirstOrDefault(t => t.ReportId.Equals(reportId));
            if (transcriptionToDelete is null) { return; }

            Transcriptions.Remove(transcriptionToDelete);
        }

        public void DeleteTransaction(Transcription transcription)
        {
            DeleteTranscriptionByReportId(transcription.ReportId);
        }
        #endregion
    }
}
