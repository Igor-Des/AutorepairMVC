namespace AutorepairMVC.ViewModels
{
    public enum SortState
    {
        No, // не сортировать
        MechanicAsc,    // по топливу по возрастанию
        MechanicDesc,   // по топливу по убыванию
        CarAsc, // по емкости возрастанию
        CarDesc    // по емкости по убыванию
    }

    public class SortViewModel
    {
        public SortState MechanicTypeSort { get; set; } // значение для сортировки по механикам
        public SortState CarTypeSort { get; set; }    // значение для сортировки по машинам
        public SortState CurrentState { get; set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            MechanicTypeSort = sortOrder == SortState.MechanicAsc ? SortState.MechanicDesc : SortState.MechanicAsc;
            CarTypeSort = sortOrder == SortState.CarAsc ? SortState.CarDesc : SortState.CarAsc;
            CurrentState = sortOrder;
        }
    }
}
