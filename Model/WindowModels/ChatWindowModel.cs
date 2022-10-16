﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.MonthCalendar;

namespace NotepadPlusPlusPlus.Model.WindowModels
{
    public class ChatWindowModel : TextboxModel
    {
        private int _maxMessageLength = 128;

        private string? _messagesArea = "<Ismael> Hola!\n<Macarena> Cállate pedazo de gilipollas o te corto las piernas.\n\n";
		public string MessagesArea
		{
			get => _messagesArea ?? string.Empty;
			set
			{
				_messagesArea = value;
				OnPropertyChanged();
                OnPropertyChanged(nameof(Text));
            }
		}

        private string? _notificationsArea = "--> Notificación!\n";
        public string NotificationsArea
        {
            get => _notificationsArea ?? string.Empty;
            set
            {
                _notificationsArea = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Text));
            }
        }

        private string? _chatCursorArea = "> ";
        public string ChatCursorArea
        {
            get => _chatCursorArea ?? string.Empty;
            set
            {
                _chatCursorArea = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Text));
            }
        }        
        
        private string? _chatArea;
        public string ChatArea
        {
            get => _chatArea ?? string.Empty;
            set
            {
                _chatArea = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(CharacterCountFormatted));
            }
        }

        public int ChatAreaStart => MessagesArea.Length + NotificationsArea.Length + ChatCursorArea.Length;

        public new string Text
        {
            get => MessagesArea + NotificationsArea + ChatCursorArea + ChatArea;
            set
            {
                string newChat = value.Substring(ChatAreaStart);
                if (newChat.Length > _maxMessageLength) return;

                ChatArea = newChat;
                OnPropertyChanged();
            }
        }

        public string CharacterCountFormatted => $"{_maxMessageLength - ChatArea.Length}/{_maxMessageLength}";

    }
}
