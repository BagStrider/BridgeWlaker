public class ColumnPair
{
    public Column FristColumn => _first;
    public Column SecondColumn => _second;

    private Column _first;
    private Column _second;

    public void SetColumnPair(Column first, Column second)
    {
        _first = first;
        _second = second;
    }
}