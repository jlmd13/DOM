using System;
using System.Collections.Generic;
using System.Linq;

namespace DOM.Transcriptions
{
    public class TranscriptionPack
    {
        #region Constructors

        public TranscriptionPack(int max)
        {
            Transcriptions = new List<Transcription>();
            MaxTranscriptionPackSize = max;
        }

        #endregion

        #region Public Properties

        public List<Transcription> Transcriptions { private set; get; }

        public int MaxTranscriptionPackSize { get; private set; }

        #endregion 

        #region Public Methods

        public void AddTranscription(string path, int userId)
        {
            if (Transcriptions.Count() >= MaxTranscriptionPackSize) { return; }
            Transcription newTranscription = new Transcription(path, userId);
            newTranscription.PropertyChanged += FinishedTranscription_PropertyChanged;
            Transcriptions.Add(newTranscription);
        }

        #endregion

        #region Private Method

        private void FinishedTranscription_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!e.PropertyName.Equals(nameof(Transcription.Finished))) { return; }
            throw new NotImplementedException();
        }

        #endregion
    }
}
