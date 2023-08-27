using DOM.TranscriptionService;
using DOM.TranscriptionService.Enums;
using System;
using System.Collections.Generic;

namespace DOM.Transcriptions
{
    public class TranscriptionServiceMock
    {
        #region Private Variables

        private Dictionary<TranscriptionTypeEnum, string> TranscriptionResults;

        #endregion

        #region Constructor
        public TranscriptionServiceMock()
        {
            InitializeResults();
        }

        #endregion

        #region Public Methods

        public TranscriptionResult TranscriptFile(string fileName)
        {
            //Se simula un 5% de resultados erróneos
            if (new Random().Next(1, 100) < 6) { return new TranscriptionResult(TranscriptionStatusEnum.TranscriptionError, string.Empty); }

            if (!Enum.TryParse(fileName, out TranscriptionTypeEnum transcriptionResult)) 
            { 
                return new TranscriptionResult(TranscriptionStatusEnum.FileNameNotValid, string.Empty); 
            }

            return new TranscriptionResult(TranscriptionStatusEnum.Ok, TranscriptionResults[transcriptionResult]);
        }

        #endregion

        #region Private Methods

        private void InitializeResults()
        {
            //Se informa el diccionario de resultados mock con los mensajes de prueba 
            TranscriptionResults = new Dictionary<TranscriptionTypeEnum, string>();
            TranscriptionResults.Add(TranscriptionTypeEnum.Cardiologia, "Texto transcrito de prueba para cardiologia");
            TranscriptionResults.Add(TranscriptionTypeEnum.Otorrinologia, "Texto transcrito de prueba para otorrinologia");
            TranscriptionResults.Add(TranscriptionTypeEnum.Dermatologia, "Texto transcrito de prueba para dermatologia");
            TranscriptionResults.Add(TranscriptionTypeEnum.Radiologia, "Texto transcrito de prueba para radiologia");
        }

        #endregion
    }
}
