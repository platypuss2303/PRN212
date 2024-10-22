using Newtonsoft.Json;
using PRN212.Customize_Page;
using PRN212.Help_page;
using PRN212.Home;
using PRN212.Settings_page;
using PRN212.Tasks_page;
using Syncfusion.UI.Xaml.Scheduler;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PRN212.Calendar_Page
{
    /// <summary>
    /// Interaction logic for CalendarWindow.xaml
    /// </summary>
    public partial class CalendarWindow : Window
    {

        public ScheduleAppointmentCollection Appointments { get; set; } = new ScheduleAppointmentCollection();

        public ScheduleAppointment SelectedAppointment { get; set; }

        public DateTime? SelectedCellDateTime { get; set; }
        public CalendarWindow()
        {
            InitializeComponent();

            UsernameTextBlock.Text = CurrentUser.User.Username;
            EmailTextBlock.Text = CurrentUser.User.Email;

            Calendar.AppointmentDeleting += Calendar_AppointmentDeleting;
            Calendar.ReminderAlertOpening += Scheduler_ReminderAlertOpening;
            Calendar.ReminderAlertActionChanged += OnScheduleReminderAlertActionChanged;

            LoadEvents();
            ShowEvents();
            UploadEventsInCalendar();

            Calendar.ItemsSource = Appointments;
        }

        public class Reminder
        {
            public bool Dismissed { get; set; }
            public TimeSpan TimeInterval { get; set; }
        }

        private static HomeWindow homeWindow;
        private void PáginaInicial_Click(object sender, RoutedEventArgs e)
        {
            if (homeWindow == null || !homeWindow.IsVisible)
            {
                homeWindow = new HomeWindow();
            }

            homeWindow.Show();
            this.Close();
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            CalendarWindow mainWindow = new CalendarWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow mainWindow = new TaskWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Customize_Click(object sender, RoutedEventArgs e)
        {
            CustomizeWindow mainWindow = new CustomizeWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow mainWindow = new SettingsWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Helper_Click(object sender, RoutedEventArgs e)
        {
            HelperWindow mainWindow = new HelperWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private string arquivoEventos = @"C:\Users\FPT SHOP\source\repos\ToDo.It-App\UTAD.ToDo.It-App\Aplicação ToDo.IT\SaveData\eventos.json";
        private void SaveEvents()
        {
            
        }

        private void LoadEvents()
        {
            
        }
        
        //public List<Event> ShowEvents()
        //{
        //    return event;
        //}

        private ObservableCollection<SchedulerReminder> ConverterLembretes(ObservableCollection<Reminder> reminders)
        {
            if (reminders == null)
                return null;

            var schedulerReminders = new ObservableCollection<SchedulerReminder>();
            foreach (var reminder in reminders)
            {
                schedulerReminders.Add(new SchedulerReminder
                {
                    IsDismissed = reminder.Dismissed,
                    ReminderTimeInterval = reminder.TimeInterval
                });
            }
            return schedulerReminders;
        }

        //private void UploadEventsInCalendar()
        //{
        //    Appointments.Clear();

        //    foreach (var evento in eventos)
        //    {
        //        ObservableCollection<SchedulerReminder> schedulerReminders = new ObservableCollection<SchedulerReminder>();

        //        if (evento.Reminders != null)
        //        {
        //            foreach (var reminder in evento.Reminders)
        //            {
        //                schedulerReminders.Add(new SchedulerReminder
        //                {
        //                    IsDismissed = reminder.Dismissed,
        //                    ReminderTimeInterval = reminder.TimeInterval
        //                });
        //            }
        //        }

        //        ScheduleAppointment appointment = new ScheduleAppointment
        //        {
        //            Id = evento.Id,
        //            Subject = evento.Titulo,
        //            Location = evento.Local,
        //            Notes = evento.Descrição,
        //            StartTime = evento.DataInicio,
        //            EndTime = evento.DataFim,
        //            IsAllDay = evento.AllDay,
        //            AppointmentBackground = evento.Cor,
        //            Foreground = evento.CorTexto,
        //            Reminders = schedulerReminders,
        //            RecurrenceRule = evento.RecurrenceRule
        //        };

        //        Appointments.Add(appointment);
        //    }
        //}

        //private void Calendar_AppointmentEditorClosing(object sender, Syncfusion.UI.Xaml.Scheduler.AppointmentEditorClosingEventArgs e)
        //{
        //    if (e.Appointment != null)
        //    {
        //        ObservableCollection<SchedulerReminder> reminders = e.Appointment.Reminders ?? new ObservableCollection<SchedulerReminder>();

        //        Evento novoEvento = new Evento
        //        {
        //            Id = (int)e.Appointment.Id,
        //            UserID = CurrentUser.User.Id,
        //            Titulo = e.Appointment.Subject,
        //            Local = string.IsNullOrEmpty(e.Appointment.Location) ? "Não Definida" : e.Appointment.Location,
        //            Descrição = e.Appointment.Notes,
        //            DataInicio = e.Appointment.IsAllDay ? e.Appointment.StartTime.Date : e.Appointment.StartTime,
        //            DataFim = e.Appointment.IsAllDay ? e.Appointment.EndTime.Date : e.Appointment.EndTime,
        //            AllDay = e.Appointment.IsAllDay,
        //            Cor = e.Appointment.AppointmentBackground,
        //            RecurrenceRule = e.Appointment.RecurrenceRule,
        //            CorTexto = e.Appointment.Foreground,
        //            Reminders = new ObservableCollection<Reminder>(
        //                reminders.Select(r => new Reminder
        //                {
        //                    Dismissed = r.IsDismissed,
        //                    TimeInterval = r.ReminderTimeInterval
        //                })
        //            ),
        //            // Adiciona a importância como vazia por padrão
        //            Importancia = Importancia.Indiferente
        //        };

        //        // Verifica se o evento já existe na lista
        //        var eventoExistente = eventos.FirstOrDefault(x => x.Id == novoEvento.Id);

        //        if (eventoExistente != null)
        //        {
        //            // Atualiza o evento existente
        //            eventoExistente.Titulo = novoEvento.Titulo;
        //            eventoExistente.Local = novoEvento.Local;
        //            eventoExistente.Descrição = novoEvento.Descrição;
        //            eventoExistente.DataInicio = novoEvento.DataInicio;
        //            eventoExistente.DataFim = novoEvento.DataFim;
        //            eventoExistente.AllDay = novoEvento.AllDay;
        //            eventoExistente.Cor = novoEvento.Cor;
        //            eventoExistente.CorTexto = novoEvento.CorTexto;
        //            eventoExistente.Reminders = novoEvento.Reminders;
        //            eventoExistente.RecurrenceRule = novoEvento.RecurrenceRule;
        //        }
        //        else
        //        {
        //            // Adiciona o novo evento à lista
        //            eventos.Add(novoEvento);
        //        }

        //        MostrarEventos();
        //        SalvarEventos();
        //    }
        //}

        //private void Calendar_AppointmentDeleting(object sender, Syncfusion.UI.Xaml.Scheduler.AppointmentDeletingEventArgs e)
        //{
        //    if (e.Appointment != null)
        //    {
        //        // Encontra o evento correspondente na lista
        //        var evento = eventos.FirstOrDefault(x => x.Id == (int)e.Appointment.Id);

        //        if (evento != null)
        //        {
        //            // Remove o evento da lista
        //            eventos.Remove(evento);
        //        }

        //        MostrarEventos();
        //        SalvarEventos();
        //        CarregarEventosNoCalendario();
        //    }
        //}


        //private ScheduleAppointment draggedAppointment;

        //private void Calendar_AppointmentDragStarting(object sender, Syncfusion.UI.Xaml.Scheduler.AppointmentDragStartingEventArgs e)
        //{
        //    draggedAppointment = e.Appointment as ScheduleAppointment;
        //}

        //private void Calendar_AppointmentDropping(object sender, Syncfusion.UI.Xaml.Scheduler.AppointmentDroppingEventArgs e)
        //{
        //    if (draggedAppointment != null)
        //    {
        //        // Encontra o evento correspondente na lista
        //        var evento = eventos.FirstOrDefault(x => x.Id == (int)e.Appointment.Id);

        //        if (evento != null)
        //        {
        //            // Calcula a duração do compromisso
        //            var duration = draggedAppointment.EndTime - draggedAppointment.StartTime;

        //            // Atualiza a data de início e fim do evento
        //            evento.DataInicio = e.DropTime;
        //            evento.DataFim = e.DropTime.Add(duration);
        //        }

        //        MostrarEventos();
        //        SalvarEventos();
        //    }

        //    draggedAppointment = null;
        //}

        //private void Scheduler_ReminderAlertOpening(object sender, ReminderAlertOpeningEventArgs e)
        //{
        //    var reminders = e.Reminders;
        //    var appointment = e.Reminders[0].Appointment;
        //}

        //private void OnScheduleReminderAlertActionChanged(object sender, Syncfusion.UI.Xaml.Scheduler.ReminderAlertActionChangedEventArgs e)
        //{
        //    if (e.ReminderAction == ReminderAction.Dismiss)
        //    {
        //        var reminder = e.Reminders[0];

        //        var evento = eventos.FirstOrDefault(x => x.Id == (int)reminder.Appointment.Id);
        //        if (evento != null)
        //        {
        //            var eventoReminder = evento.Reminders.FirstOrDefault(r => r.TimeInterval == reminder.ReminderTimeInterval);
        //            if (eventoReminder != null)
        //            {
        //                evento.Reminders.Remove(eventoReminder);
        //            }

        //            SalvarEventos();
        //        }
        //    }
        //    else if (e.ReminderAction == ReminderAction.DismissAll)
        //    {
        //        var reminders = e.Reminders;

        //        foreach (var reminder in reminders)
        //        {
        //            var evento = eventos.FirstOrDefault(x => x.Id == (int)reminder.Appointment.Id);
        //            if (evento != null)
        //            {
        //                var eventoReminder = evento.Reminders.FirstOrDefault(r => r.TimeInterval == reminder.ReminderTimeInterval);
        //                if (eventoReminder != null)
        //                {
        //                    eventoReminder.Dismissed = true;
        //                }
        //            }
        //        }

        //        SalvarEventos();
        //    }
        //    else if (e.ReminderAction == ReminderAction.Snooze)
        //    {
        //        var reminder = e.Reminders[0];
        //        var snoozeTime = e.SnoozeTime;
        //    }
        //}

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if (menuItem.Header is "Editar")
            {
                if (this.SelectedAppointment != null)
                {
                    var evento = eventos.FirstOrDefault(x => x.Id == (int)SelectedAppointment.Id);
                    PáginaEditarTarefa editarTarefaWindow = new PáginaEditarTarefa(evento);
                    editarTarefaWindow.Owner = this;
                    editarTarefaWindow.ShowDialog();
                }
            }

            else if (menuItem.Header is "Adicionar")
            {
                Evento newEvent = new Evento();
                newEvent.DataInicio = (DateTime)this.SelectedCellDateTime;
                newEvent.DataFim = (DateTime)this.SelectedCellDateTime;
                PáginaEditarTarefa editarTarefaWindow = new PáginaEditarTarefa(newEvent);
                editarTarefaWindow.Owner = this;
                editarTarefaWindow.ShowDialog();
            }
        }

        private void Calendar_SchedulerContextMenuOpening(object sender, SchedulerContextMenuOpeningEventArgs e)
        {
            this.SelectedAppointment = e.MenuInfo.Appointment;
            this.SelectedCellDateTime = e.MenuInfo.DateTime;
        }

        private void Calendar_ReminderAlertOpening(object sender, ReminderAlertOpeningEventArgs e)
        {
            Evento evento = eventos.FirstOrDefault(x => x.Id == (int)e.Reminders[0].Appointment.Id);
            string fromMail = "todoitapplab@gmail.com";
            string fromPassword = "vyte qpsw zktv xovx";
            string toMail = CurrentUser.User.Email;
            string subject = "Lembrete";
            string body = $"Tem uma tarefa prestes a começar: \n Titulo:{evento.Titulo},\n Data:{evento.DataInicio}, \n Importância:{evento.Importancia}, \n Localização:{evento.Local}";

            MailMessage messagetouser = new MailMessage(fromMail, toMail)
            {
                Subject = subject,
                Body = body,

            };

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            try
            {
                smtpClient.Send(messagetouser);



            }
            catch (System.Exception ex)
            {

            }
        }
    }


}

