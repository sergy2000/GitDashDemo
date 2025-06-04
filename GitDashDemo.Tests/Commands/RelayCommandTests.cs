using GitDashDemo;
using Xunit;

namespace GitDashDemo.Tests.Commands
{
    public class RelayCommandTests
    {
        [Fact]
        public void Execute_CallsProvidedAction()
        {
            bool executed = false;
            var command = new RelayCommand(() => executed = true);

            command.Execute(null);

            Assert.True(executed);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CanExecute_ReturnsDelegateResult(bool expected)
        {
            var command = new RelayCommand(() => { }, () => expected);

            bool result = command.CanExecute(null);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Execute_WithParameterAction_ReceivesParameter()
        {
            object? received = null;
            var param = new object();
            var command = new RelayCommand(p => received = p);

            command.Execute(param);

            Assert.Same(param, received);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CanExecute_WithParameter_ReturnsDelegateResult(bool expected)
        {
            var command = new RelayCommand(_ => { }, _ => expected);

            bool result = command.CanExecute(new object());

            Assert.Equal(expected, result);
        }
    }
}
