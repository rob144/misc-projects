using System;
using System.Data;
using System.Collections.Generic;

namespace PGAspNet
{
    public class RDataResult
    {
        private int _intResult;
        private DataTable _data;
        private String _exception = "";

        public RDataResult() { }

        public int intResult
        {
            get
            {
                return _intResult;
            }
            set
            {
                _intResult = value;
            }
        }

        public DataTable dataTable
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public String err
        {
            get
            {
                return _exception = (_exception != null ? _exception : "");
            }
            set
            {
                _exception = value;
            }
        }

    }
}