namespace AutorepairMVC.ViewModels
{
    public enum SortState
    {
        No, // не сортировать
        MechanicTypeAsc,    
        MechanicTypeDesc,   
        CostTypeAsc,
        CostTypeDesc   
    }

    public class SortViewModel
    {
        public SortState MechanicTypeSort { get; set; } // значение для сортировки по механикам
        public SortState CostTypeSort { get; set; }    // значение для сортировки по цене 
        public SortState CurrentState { get; set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            MechanicTypeSort = sortOrder == SortState.MechanicTypeAsc ? SortState.MechanicTypeDesc : SortState.MechanicTypeAsc;
            CostTypeSort = sortOrder == SortState.CostTypeAsc ? SortState.CostTypeDesc : SortState.CostTypeAsc;
            CurrentState = sortOrder;
        }
    }
}
