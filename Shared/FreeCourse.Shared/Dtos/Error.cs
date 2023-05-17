using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Shared.Dtos
{
    public class Error
    {
        public List<string> Errors { get; private set; } = new List<string>();
        public bool IsShow { get; private set; }

        public Error(string error, bool isShow) 
        { 
            Errors.Add(error);
            IsShow = isShow;
        }
        public Error(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }

    }
}
