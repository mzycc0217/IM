# IM

         生成UserSig方法
         
         //AppsdkId //Key
            TLSSigAPIv2 tLSSigAPIv2 = new TLSSigAPIv2(1400418683, "74ef0e144451dad38cd534685cad69e1d426ae02834ba97448e23f7602cb748c");

            //   var sin=   Sigins.GenUserSig("12dasdsa", "21dasdsadsdad", "12345", 300);

            //发起语音通话的人的id
            var p = tLSSigAPIv2.GenSig(liveModel.StringName, 1000);
            return p;
