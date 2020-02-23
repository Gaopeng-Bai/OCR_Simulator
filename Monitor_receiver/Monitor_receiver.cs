using System.Windows.Forms;

namespace Monitor_receiver
{
    public partial class Client : Form
    {
        DllClass label_listen= new DllClass();
        server ser;
        private void Add(string v1, string v2, string v3, string v4)
        {
            label1.Text = v1;
            label2.Text = v2;
            label3.Text = v3;
            label4.Text = v4;
        }

        public Client()
        {   
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            label_listen.SetAddCallBack(Add);
            ser = new server(label_listen);
            ser.run();

        }
    }
}
