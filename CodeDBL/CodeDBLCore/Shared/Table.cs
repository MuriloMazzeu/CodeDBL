namespace CodeDBLCore.Shared
{
    public class Table
    {
        public bool WasMapped { get; private set; }

        public Table()
        {
            WasMapped = GetType().IsDefined(typeof(TableAttribute), false);
        }
    }
}
