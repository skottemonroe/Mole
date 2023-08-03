namespace mole {
    internal class filetype {

        public string ext;
        public long bytes;
        public int count;

        public filetype(string extension, long bytes) {
            this.ext = extension.ToLower();
            this.bytes = bytes;
            this.count = 1;
        }

        //BYTES is a simple count of the number if bytes in a fFile.
        //SIZE is a fFormatted string description.  It's basically just fFactors of a thousand.

        public string size() {
            decimal dblOut = 0;
            string strUnit = " Bytes";
            string strOut;

            decimal Kb = 1000;
            decimal Mb = 1000000;
            decimal Gb = 1000000000;
            decimal Tb = 1000000000000;
            decimal Pb = 1000000000000000;

            if (this.bytes < Kb) {
                dblOut = this.bytes;
                strUnit = "B";

            } else if (this.bytes < Mb) {
                dblOut = this.bytes / Kb;
                strUnit = "KB  *";

            } else if (this.bytes < Gb) {
                dblOut = this.bytes / Mb;
                strUnit = "MB  **";

            } else if (this.bytes < Tb) {
                dblOut = this.bytes / Gb;
                strUnit = "GB  ***";

            } else if (this.bytes < Pb) {
                dblOut = this.bytes / Tb;
                strUnit = "TB  ****";

            } else {
                dblOut = this.bytes / Pb;
                strUnit = "PB  ******";

            }

            strOut = $" {dblOut.ToString("##0.00"),6} {strUnit}";
            return strOut;
        }


    }
}
