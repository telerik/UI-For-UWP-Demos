using System;
using System.Linq;

namespace QSF.Infrastructure.Model
{
    public class CodeFileInfo
    {
        public string CodeContent { get; set; }

        public string Extension
        {
            get
            {
                if (string.IsNullOrEmpty(this.FileName))
                {
                    return string.Empty;
                }

                return this.FileName.Substring(this.FileName.LastIndexOf("."));
            }
        }

        public string FileName { get; set; }
    }
}