namespace TicTacToe.Foundation.Games.StepResults
{
    public class InvalidCellPositionStepResult : StepResult
    {
        public int SelectedRow { get; }
        
        public int SelectedColumn { get; }


        public InvalidCellPositionStepResult(int row, int column) 
            : base(StepResultType.InvalidCellPosition)
        {
            SelectedRow = row;
            SelectedColumn = column;
        }
    }
}