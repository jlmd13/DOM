using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace DOM.Transcriptions
{
    /// <summary>
    /// Clase que representa una transcripción
    /// </summary>
    public class Transcription : INotifyPropertyChanged
    {
        #region

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Variables

        private bool _finished;
        private readonly long maxLength = 3000000;
        private readonly long minLength = 50000;
        private readonly string mp3Extension = ".mp3";

        #endregion

        #region Constructors

        public Transcription(string filePath, int userId)
        {
            ReportId = new Guid();
            UserId = userId;
            FilePath = filePath;
            Attemps = 3;
        }

        #endregion

        #region Public Properties

        public Guid ReportId { private set; get; }

        public int UserId { private set; get; }

        public string FilePath { private set; get; }

        public string Result { set; get; }

        public int Attemps { private set; get; }

        public bool Processed { set; get; }

        public bool Finished
        {
            get => _finished;
            set
            {
                _finished = value;
                NotifyPropertyChanged();
            }
        }


        public bool IsValid => File.Exists(FilePath) && FileLengthIsValid() && ExtensionIsValid();

        #endregion

        #region Public Methods

        public bool FileLengthIsValid()
        {
            long fileLength = new FileInfo(FilePath).Length;
            return fileLength < maxLength && fileLength > minLength;
        }

        public bool ExtensionIsValid()
        {
            return new FileInfo(FilePath).Extension.Equals(mp3Extension);
        }

        public void UseAttemp()
        {
            Attemps--;
            Finished = false;
        }

        public string GetFileName()
        {
            return Path.GetFileNameWithoutExtension(new FileInfo(FilePath).Name);
        }

        #endregion

        #region Private Methods

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
