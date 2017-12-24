using System;
using System.Collections.Generic;
using System.Text;

namespace BruzeBotV2.util
{
    class SubRank
    {
        private string title, type;

        public SubRank(string title, string type)
        {
            this.title = title;
            this.type = type;
        }

        /** Getters and Setters **/

        public string getTitle()
        {
            return title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public string getType()
        {
            return type;
        }

        public void setType(string type)
        {
            this.type = type;
        }

    }
}
