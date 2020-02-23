namespace Monitor_receiver
{
    public class DllClass
    {
        public delegate void operate(string v1, string v2, string v3, string v4);
        public operate opt = null;

        public void SetAddCallBack(operate opt)
        {
            this.opt = opt;
        }
    }
}
