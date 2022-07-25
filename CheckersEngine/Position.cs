namespace CheckersEngine
{
    public class Position
    {
        public eRow Row
        {
            get;
            set;
        }

        public eColumn Column
        {
            get;
            set;
        }

        public Position(eRow i_R, eColumn i_C)
        {
            this.Row = i_R;
            this.Column = i_C;
        }
    }
}