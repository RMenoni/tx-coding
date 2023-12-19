namespace tx.Data
{
    public class LaneEntity
    {
        public LaneEntity() {
            JanCode = "";
        }
        public UInt64 Number {  get; set; }
        public string JanCode {  get; set; }
        public UInt64 Quantity {  get; set; }
        public int PositionX { get; set; }
    }
}
