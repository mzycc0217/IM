using System;
using System.Collections.Generic;
using System.Text;

namespace Coldairarrow.Util.LivePush
{
  public  class LiveModel
    {
        /// <summary>
        /// 个人id
        /// </summary>
        public string StringName { get; set; }

        /// <summary>
        /// 播流地址
        /// </summary>
        public string PlayUrl { get; set; }
        /// <summary>
        /// 推流地址
        /// </summary>
        public string PushUrl { get; set; }

    }
}
