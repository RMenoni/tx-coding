namespace tx.Data
{
    public class RowEntity
    {
        public RowEntity() {
            Lanes = new List<LaneEntity>();
            Size = new RowSizeEntity();
        }

        public UInt64 Number {  get; set; }
        public List<LaneEntity> Lanes { get; set; }
        public int PositionZ {  get; set; }
        public RowSizeEntity Size {  get; set; }
    }
}
