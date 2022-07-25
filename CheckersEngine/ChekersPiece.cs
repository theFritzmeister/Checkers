namespace CheckersEngine
{
    public enum eColor
    {
        Empty,
        WhiteO,
        BlackX
    }

    public enum ePieceType
    {
        Normal, King
    }

    public enum eRow
    {
        a,
        b,
        c,
        d,
        e,
        f,
        g,
        h,
        i,
        j
    }

    public enum eColumn
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J
    }

    public class ChekersPiece
    {
        public ePieceType m_Type { get; internal set; }

        public eColor m_Color { get; internal set; }

        internal Position m_Position
        {
            get;
            set;
        }

        public ChekersPiece(eColor i_Color, eRow i_Row, eColumn i_Column)
        {
            this.m_Color = i_Color;
            this.m_Type = ePieceType.Normal;
            this.m_Position = new Position(i_Row, i_Column);
        }

        internal void Clear()
        {
            this.m_Color = eColor.Empty;
            this.m_Type = ePieceType.Normal;
        }
    }
}
