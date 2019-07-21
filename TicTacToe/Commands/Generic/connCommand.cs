using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   using System.Windows.Input;

namespace TicTacToe.Commands.Generic
{
    class connCommand : ICommand
    {

         private Action commandTask;
  
          public connCommand(Action workToDo)
          {
              commandTask = workToDo;
          }
  
          public bool CanExecute(object parameter)
          {
              return true;
          }
  
          public event EventHandler CanExecuteChanged;
  
          public void Execute(object parameter)
          {
               commandTask();
           }
    }
}
