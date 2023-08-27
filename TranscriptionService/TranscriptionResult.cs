using DOM.TranscriptionService.Enums;

namespace DOM.TranscriptionService
{
    public class TranscriptionResult
    {
        #region Constructor

        public TranscriptionResult(TranscriptionStatusEnum status, string result)
        {
            TranscriptionStatus = status;
            Result = result;
        }

        #endregion

        #region Public Properties

        public TranscriptionStatusEnum TranscriptionStatus { private set; get; }

        public string Result { private set; get; }

        #endregion
    }
}
