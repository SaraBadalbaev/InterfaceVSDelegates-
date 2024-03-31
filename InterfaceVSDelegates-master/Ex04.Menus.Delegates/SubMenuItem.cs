namespace Ex04.Menus.Delegates
{
    public delegate void ClickEventHandler();

    public class SubMenuItem : MenuItem
    {
        public event ClickEventHandler m_Click;

        public SubMenuItem(string i_SubTitle) : base(i_SubTitle) 
        {  
        }

        public override void OnClick()
        {
            if (m_Click != null) 
            {
                m_Click.Invoke();
            }
        }
    }
}
