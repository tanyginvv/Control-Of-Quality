using lab6TV;
using Xunit;

namespace TVTests
{
    public class TestsTV
    {
        private readonly TV _tv;
        public TestsTV()
        {
            _tv = new();
        }

        [Fact]
        public void Get_info_of_just_created_TV()
        {
            // arrange

            // act
            var (isOn, currentChannel) = _tv.GetTVInfo();

            // assert
            Assert.True(!isOn, $"[Get_info_of_just_created_TV] TV should be turned off by default.");
            Assert.True(currentChannel == 0, $"[Get_info_of_just_created_TV] Current channel should be 0 by default.");
        }

        [Fact]
        public void Turning_on_when_TV_turned_off()
        {
            // arrange

            // act
            _tv.TurnTVOn();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(isOn, $"[Turning_on_when_TV_turned_off] TV should be turned on.");
            Assert.True(currentChannel == 1, $"[Turning_on_when_TV_turned_off] Current channel should be set to 1 after turning on.");
        }

        [Fact]
        public void Turning_on_when_TV_turned_on()
        {
            // arrange
            _tv.TurnTVOn();

            // act
            _tv.TurnTVOn();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(isOn, $"[Turning_on_when_TV_turned_on] TV should remain turned on.");
            Assert.True(currentChannel == 1, $"[Turning_on_when_TV_turned_on] Current channel should remain unchanged.");
        }

        [Fact]
        public void Turned_off_TV_always_shows_channel_zero()
        {
            // arrange
            _tv.TurnTVOn();
            _tv.SetTVChannel(10);

            // act
            _tv.TurnTVOff();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(!isOn, $"[Turned_off_TV_always_shows_channel_zero] TV should be turned off.");
            Assert.True(currentChannel == 0, $"[Turned_off_TV_always_shows_channel_zero] Current channel should be set to 0 after turning off.");
        }

        [Fact]
        public void Turning_off_when_TV_turned_on()
        {
            // arrange
            _tv.TurnTVOn();

            // act
            _tv.TurnTVOff();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(!isOn, $"[Turning_off_when_TV_turned_on] TV should be turned off after turning off.");
            Assert.True(currentChannel == 0, $"[Turning_off_when_TV_turned_on] Current channel should be set to 0 after turning off.");
        }

        [Fact]
        public void Turning_off_when_TV_turned_off()
        {
            // arrange

            // act
            _tv.TurnTVOff();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(!isOn, $"[Turning_off_when_TV_turned_off] TV should remain turned off.");
            Assert.True(currentChannel == 0, $"[Turning_off_when_TV_turned_off] Current channel should remain 0 when TV is already off.");
        }

        [Fact]
        public void Select_channel_on_turned_off_TV()
        {
            // arrange

            // act
            _tv.SetTVChannel(10);

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(!isOn, $"[Select_channel_on_turned_off_TV] TV should remain turned off after attempting to set channel.");
            Assert.True(currentChannel == 0, $"[Select_channel_on_turned_off_TV] Current channel should remain 0 when TV is off.");
        }

        [Fact]
        public void Select_channel_on_turned_on_TV()
        {
            // arrange
            _tv.TurnTVOn();

            // act
            _tv.SetTVChannel(5);

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(isOn, $"[Select_channel_on_turned_on_TV] TV should remain turned on.");
            Assert.True(currentChannel == 5, $"[Select_channel_on_turned_on_TV] Current channel should be set to the selected channel.");
        }

        [Fact]
        public void Select_channel_with_minimum_number()
        {
            // arrange
            _tv.TurnTVOn();

            // act
            _tv.SetTVChannel(1);

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(isOn, $"[Select_channel_with_minimum_number] TV should remain turned on.");
            Assert.True(currentChannel == 1, $"[Select_channel_with_minimum_number] Current channel should be set to the minimum available channel.");
        }

        [Fact]
        public void Select_channel_with_number_zero()
        {
            // arrange
            _tv.TurnTVOn();

            // act
            _tv.SetTVChannel(0);

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(isOn, $"[Select_channel_with_number_zero] TV should remain turned on.");
            Assert.True(currentChannel == 1, $"[Select_channel_with_number_zero] Current channel should not be set to 0.");
        }

        [Fact]
        public void Select_channel_with_negative_number()
        {
            // arrange
            _tv.TurnTVOn();

            // act
            _tv.SetTVChannel(-1);

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(isOn, $"[Select_channel_with_negative_number] TV should remain turned on.");
            Assert.True(currentChannel == 1, $"[Select_channel_with_negative_number] Current channel should not be set to a negative number.");
        }

        [Fact]
        public void Select_channel_with_max_number()
        {
            // arrange
            _tv.TurnTVOn();

            // act
            _tv.SetTVChannel(100);

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(isOn, $"[Select_channel_with_max_number] TV should remain turned on.");
            Assert.True(currentChannel == 100, $"[Select_channel_with_max_number] Current channel should be set to the maximum available channel.");
        }

        [Fact]
        public void Select_channel_with_number_more_than_100()
        {
            // arrange
            _tv.TurnTVOn();

            // act
            _tv.SetTVChannel(101);

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(isOn, $"[Select_channel_with_number_more_than_100] TV should remain turned on.");
            Assert.True(currentChannel == 1, $"[Select_channel_with_number_more_than_100] Current channel should not be set to a number greater than 100.");
        }

        [Fact]
        public void Select_previous_channel_after_first_turning_on_TV()
        {
            // arrange
            _tv.TurnTVOn();

            // act
            _tv.SetTVPreviousChannel();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(currentChannel == 1, $"[Select_previous_channel_after_first_turning_on_TV] Previous channel should be equal to the current channel after the first turning on of the TV.");
        }

        [Fact]
        public void Select_previous_channel_after_select_another_channel()
        {
            // arrange
            _tv.TurnTVOn();
            _tv.SetTVChannel(5);
            _tv.SetTVChannel(7);

            // act
            _tv.SetTVPreviousChannel();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(currentChannel == 5, $"[Select_previous_channel_after_select_another_channel] Previous channel should be set to the previously selected channel.");
        }

        [Fact]
        public void Select_previous_channel_after_select_one_channel()
        {
            // arrange
            _tv.TurnTVOn();
            _tv.SetTVChannel(7);

            // act
            _tv.SetTVPreviousChannel();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(currentChannel == 1, $"[Select_previous_channel_after_select_one_channel] Previous channel should be set to the first channel (1) after selecting one channel.");
        }

        [Fact]
        public void Select_previous_channel_after_turning_off_and_turning_on()
        {
            // arrange
            _tv.TurnTVOn();
            _tv.SetTVChannel(5);
            _tv.SetTVChannel(7);
            _tv.TurnTVOff();
            _tv.TurnTVOn();

            // act
            _tv.SetTVPreviousChannel();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(currentChannel == 5, $"[Select_previous_channel_after_turning_off_and_turning_on] Previous channel should be set to the previously selected channel after turning off and then on the TV.");
        }

        [Fact]
        public void Select_previous_channel_after_two_times_selecting_same_channel()
        {
            // arrange
            _tv.TurnTVOn();
            _tv.SetTVChannel(5);
            _tv.SetTVChannel(7);
            _tv.SetTVChannel(7);

            // act
            _tv.SetTVPreviousChannel();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(currentChannel == 5, $"[Select_previous_channel_after_two_times_selecting_same_channel] Previous channel should be set to the previously selected channel.");
        }

        [Fact]
        public void Select_previous_channel_two_times()
        {
            // arrange
            _tv.TurnTVOn();
            _tv.SetTVChannel(5);
            _tv.SetTVChannel(7);

            // act
            _tv.SetTVPreviousChannel();
            _tv.SetTVPreviousChannel();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(currentChannel == 7, $"[Select_previous_channel_two_times] After selecting previous channel twice, current channel should be set to the second previously selected channel.");
        }

        [Fact]
        public void Select_previous_channel_on_turned_off_TV()
        {
            // arrange
            _tv.TurnTVOn();
            _tv.SetTVChannel(5);
            _tv.SetTVChannel(7);
            _tv.TurnTVOff();

            // act
            _tv.SetTVPreviousChannel();
            _tv.TurnTVOn();

            // assert
            var (isOn, currentChannel) = _tv.GetTVInfo();
            Assert.True(currentChannel == 7, $"[Select_previous_channel_on_turned_off_TV] Previous channel should be set to the last selected channel after turning on the TV.");
        }
    }
}
