using IPA.Utilities;
using MorePreciseNoteJumpDuration.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace MorePreciseNoteJumpDuration.Managers
{
    class NoteJumpDurationManager : IInitializable
    {
        private GameplaySetupViewController _gameplaySetupViewController;
        private PluginConfig _config;

        public NoteJumpDurationManager(GameplaySetupViewController gameplaySetupViewController, PluginConfig config)
        {
            _gameplaySetupViewController = gameplaySetupViewController;
            _config = config;
        }

        public void Initialize()
        {
            if (_gameplaySetupViewController == null)
            {
                return;
            }

            PlayerSettingsPanelController playerSettingsPanelController = _gameplaySetupViewController.GetField<PlayerSettingsPanelController, GameplaySetupViewController>("_playerSettingsPanelController");
            FormattedFloatListSettingsController noteJumpDurationTypeSettingsDropdown = playerSettingsPanelController.GetField<FormattedFloatListSettingsController, PlayerSettingsPanelController>("_noteJumpFixedDurationSettingsController");

            float min_value = noteJumpDurationTypeSettingsDropdown.values[0];
            float max_value = noteJumpDurationTypeSettingsDropdown.values[noteJumpDurationTypeSettingsDropdown.values.Length - 1];
            noteJumpDurationTypeSettingsDropdown.SetField("_formattingString", "{0:0.000} s");
            noteJumpDurationTypeSettingsDropdown.values = GetValues(min_value, max_value);

        }

        private float[] GetValues(float min_value, float max_value)
        {
            float[] values = new float[CalculateNumberOfElements(min_value, max_value)];
            int j = 0;
            for (float i = min_value; i <= max_value; i += _config.Step)
            {
                values[j] = i;
                j++;
            }
            return values;
        }

        private int CalculateNumberOfElements(float min_value, float max_value)
        {
            return ((int) Math.Round((max_value - min_value) / _config.Step)) + 1;
        }
    }
}
