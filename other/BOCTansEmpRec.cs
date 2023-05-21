using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductClass.API
{
    public class BOCTansEmpRec
    {
        public BOCTansEmpRec()
        {
            InitFields();
        }

        private string _Filler1;
        private string _DestinationBankNo;
        private string _DestinationBranchNo;
        private string _DestinationAccNo;
        private string _DestinationAccName;
        private string _TransactionCode;
        private string _ReturnCode;
        private string _Filler2;
        private string _Filler3;
        private string _Amount;
        private string _Filler4;
        private string _OriginatingBankNo;
        private string _OriginatingBranchNo;
        private string _OriginatingAccNo;
        private string _OriginatingAccName;
        private string _Particulars;
        private string _Reference;
        private DateTime _ValueDate;
        private string _Filler5;

        private void InitFields()
        {
            this._Filler1 = "0000";
            this._TransactionCode = "23";
            this._ReturnCode = "00";
            this._Filler2 = "0";
            this._Filler3 = "000000";
            this._Filler4 = "SLR";
            this._Particulars = SetValueForParticulars(15);
            this._Reference = SetValueForReference(15);
            this._Filler5 = "000000";

            //this._Filler1 = "????";
            this._DestinationBankNo = "????";
            this._DestinationBranchNo = "???";
            this._DestinationAccNo = "????????????";
            this._DestinationAccName = "????????????????????";
            //this._TransactionCode = "??";
            //this._ReturnCode = "??";
            //this._Filler2 = "?";
            //this._Filler3 = "??????";
            this._Amount = "????????????";
            //this._Filler4 = "???";
            this._OriginatingBankNo = "????";
            this._OriginatingBranchNo = "???";
            this._OriginatingAccNo = "????????????";
            this._OriginatingAccName = "????????????????????";
            //this._Particulars = "???????????????";
            //this._Reference = "???????????????";
            this.ValueDate = DateTime.MinValue;
            //this._Filler5 = "??????";
        }

        public string Filler1
        {
            get { return this._Filler1; }
            //set
            //{
            //    if (value == "0000")
            //    {
            //        throw new Exception("Filler1 should be 0000");
            //    }

            //    if (!IsNumeric(value))
            //    {
            //        throw new Exception("Only numeric valus are allowed for filler1");
            //    }

            //    this._Filler1 = value;
            //}
        }

        public string DestinationBankNo
        {
            get { return this._DestinationBankNo; }

            set
            {
                if (!IsNumeric(value))
                {
                    throw new Exception("Only numeric valus are allowed for destination banck no");
                }

                if (value.Length != 4)
                {
                    throw new Exception("Only 4 digits are allowed for destination banck no");
                }

                this._DestinationBankNo = value;
            }
        }

        public string DestinationBranchNo
        {
            get { return this._DestinationBranchNo; }

            set
            {
                if (!IsNumeric(value))
                {
                    throw new Exception("Only numeric valus are allowed for destination branch no");
                }

                if (value.Length != 3)
                {
                    throw new Exception("Only 3 digits are allowed for destination branch no");
                }

                this._DestinationBranchNo = value;
            }
        }

        public string DestinationAccNo
        {
            get { return this._DestinationAccNo; }

            set
            {
                if (value.Length > 12)
                {
                    throw new Exception("Only 12 numeric valus are allowed for destination account no");
                }

                if (!IsNumeric(value))
                {
                    throw new Exception("Only numeric valus are allowed for destination account no");
                }

                if (value.Length < 12)
                {
                    this._DestinationAccNo = FillValueWithLeadingOrPrecedingChars(value, 12, "0", false);
                }
                else if (value.Length == 12)
                {
                    this._DestinationAccNo = value;
                }
            }
        }

        public string DestinationAccName
        {
            get { return this._DestinationAccName; }

            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Destination account name can not be empty");
                }

                if (value.Length == 20)
                {
                    this._DestinationAccName = value;
                }
                else if (value.Length > 20)
                {
                    this._DestinationAccName = SplitAccountName(value, 20);
                }
                else if (value.Length < 20)
                {
                    this._DestinationAccName = FillValueWithLeadingOrPrecedingChars(value, 20, " ", true);
                }
            }
        }

        public string TransactionCode
        {
            get { return this._TransactionCode; }
        }

        public string ReturnCode
        {
            get { return this._ReturnCode; }
        }

        public string Filler2
        {
            get { return this._Filler2; }
        }

        public string Filler3
        {
            get { return this._Filler3; }
        }

        public string Amount
        {
            get { return this._Amount; }

            set
            {
                if (!IsDecimal(value))
                {
                    throw new Exception("Only decimal values are allowed for amount");
                }



                this._Amount = FillValueWithLeadingOrPrecedingChars(value, 12, "0", false);
            }
        }

        public string Filler4
        {
            get { return this._Filler4; }
        }

        public string OriginatingBankNo
        {
            get { return this._OriginatingBankNo; }

            set
            {
                if (!IsNumeric(value))
                {
                    throw new Exception("Only numeric valus are allowed for originating banck no");
                }

                if (value.Length != 4)
                {
                    throw new Exception("Only 4 digits are allowed for originating banck no");
                }

                this._OriginatingBankNo = value;
            }
        }

        public string OriginatingBranchNo
        {
            get { return this._OriginatingBranchNo; }

            set
            {
                if (!IsNumeric(value))
                {
                    throw new Exception("Only numeric valus are allowed for originating branch no");
                }

                if (value.Length != 3)
                {
                    throw new Exception("Only 3 digits are allowed for originating branch no");
                }

                this._OriginatingBranchNo = value;
            }
        }

        public string OriginatingAccNo
        {
            get { return this._OriginatingBankNo; }

            set
            {
                if (value.Length > 12)
                {
                    throw new Exception("Only 12 numeric valus are allowed for originating account no");
                }

                if (!IsNumeric(value))
                {
                    throw new Exception("Only numeric valus are allowed for originating account no");
                }

                if (value.Length < 12)
                {
                    this._OriginatingAccNo = FillValueWithLeadingOrPrecedingChars(value, 12, "0", false);
                }
                else if (value.Length == 12)
                {
                    this._OriginatingAccNo = value;
                }
            }
        }

        public string OriginatingAccName
        {
            get { return this._OriginatingAccName; }

            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Originating account name can not be empty");
                }

                if (value.Length == 20)
                {
                    this._OriginatingAccName = value;
                }
                else if (value.Length > 20)
                {
                    this._OriginatingAccName = SplitAccountName(value, 20);
                }
                else if (value.Length < 20)
                {
                    this._OriginatingAccName = FillValueWithLeadingOrPrecedingChars(value, 20, " ", true);
                }
            }
        }

        public string Particulars
        {
            get { return this._Particulars; }

            //set { }
        }

        public string Reference
        {
            get { return this._Reference; }
            //set 
            //{ 

            //}
        }

        public DateTime ValueDate
        {
            get { return this._ValueDate; }

            set
            {
                this._ValueDate = value;
            }
        }

        public string Filler5
        {
            get { return this._Filler5; }
        }

        private bool IsNumeric(string number)
        {
            Int64 intCheck = 0;
            return Int64.TryParse(number, out intCheck);
        }

        private bool IsDecimal(string number)
        {
            decimal decCheck = 0;

            return decimal.TryParse(number, out decCheck);
        }

        private string SplitAccountName(string originalValue, int accountNameLength)
        {
            return originalValue.Substring(0, accountNameLength);
        }

        private string FillValueWithLeadingOrPrecedingChars(string orginalValue, int requiredLength, string c, bool isAtEnd)
        {
            string strLeadingZeros = "";
            string valueWithLeadingZeros = "";

            if (orginalValue.Length < requiredLength)
            {
                int neededLeadingZeros = requiredLength - orginalValue.Length;

                for (int i = 0; i < neededLeadingZeros; i++)
                {
                    strLeadingZeros += c;
                }
            }

            if (isAtEnd)
            {
                valueWithLeadingZeros = orginalValue + strLeadingZeros;
            }
            else
            {
                valueWithLeadingZeros = strLeadingZeros + orginalValue;
            }

            return valueWithLeadingZeros;
        }

        private string SetValueForParticulars(int charLength)
        {
            string value = "";

            for (int i = 0; i < charLength; i++)
            {
                value += " ";
            }

            return value;
        }

        private string SetValueForReference(int charLength)
        {
            string value = "";

            for (int i = 0; i < charLength; i++)
            {
                value += " ";
            }

            return value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(150);
            sb.Append(this._Filler1);
            sb.Append(this._DestinationBankNo);
            sb.Append(this._DestinationBranchNo);
            sb.Append(this._DestinationAccNo);
            sb.Append(this._DestinationAccName);
            sb.Append(this._TransactionCode);
            sb.Append(this._ReturnCode);
            sb.Append(this._Filler2);
            sb.Append(this._Filler3);
            sb.Append(this._Amount);
            sb.Append(this._Filler4);
            sb.Append(this._OriginatingBankNo);
            sb.Append(this._OriginatingBranchNo);
            sb.Append(this._OriginatingAccNo);
            sb.Append(this._OriginatingAccName);
            sb.Append(this._Particulars);
            sb.Append(this._Reference);
            sb.Append(this._ValueDate.ToString("yyMMdd"));
            sb.Append(this._Filler5);

            #region comment
            //string fullAccRow = "";
            //fullAccRow += this._Filler1;
            //fullAccRow += this._DestinationBankNo;
            //fullAccRow += this._DestinationBranchNo;
            //fullAccRow += this._DestinationAccNo;
            //fullAccRow += this._DestinationAccName;
            //fullAccRow += this._TransactionCode;
            //fullAccRow += this._ReturnCode;
            //fullAccRow += this._Filler2;
            //fullAccRow += this._Filler3;
            //fullAccRow += this._Amount;
            //fullAccRow += this._Filler4;
            //fullAccRow += this._OriginatingBankNo;
            //fullAccRow += this._OriginatingBranchNo;
            //fullAccRow += this._OriginatingAccNo;
            //fullAccRow += this._OriginatingAccName;
            //fullAccRow += this._Particulars;
            //fullAccRow += this._Reference;
            //fullAccRow += this._ValueDate.ToString("yyMMdd");
            //fullAccRow += this._Filler5;
            #endregion

            if (sb.Length != 150)
            {
                return "??????????????????????????????????????";
            }

            return sb.ToString() ;
        }
    }
}
