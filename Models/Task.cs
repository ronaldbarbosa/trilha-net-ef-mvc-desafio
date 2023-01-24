using trilha_net_ef_mvc_desafio.Models.Enums;

namespace trilha_net_ef_mvc_desafio.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TaskStatusEnum Status { get; set; }
    }
}