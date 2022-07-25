namespace CheckersForm
{
    public class Player
    {
        public Player(string name)
        {
            m_Name = name;
            m_Score = 0;
        }

        public string m_Name { get; private set; }

        public int m_Score { get; private set; }

        public void SetScore(int i_ToAdd)
        {
            m_Score += i_ToAdd;
        }
    }
}