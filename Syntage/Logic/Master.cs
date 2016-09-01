﻿using System.Collections.Generic;
using Syntage.Framework.Parameters;
using Syntage.Logic.Audio;

namespace Syntage.Logic
{
    public class Master : AudioProcessorPartWithParameters, IProcessor
    {
        public VolumeParameter MasterVolume { get; private set; }

        public Master(AudioProcessor audioProcessor) :
            base(audioProcessor)
        {
        }

        public override IEnumerable<Parameter> CreateParameters(string parameterPrefix)
        {
            MasterVolume = new VolumeParameter(parameterPrefix + "Vol", "Master Volume", false);

            return new List<Parameter> {MasterVolume};
        }
        
        public void Process(IAudioStream stream)
        {
            var volume = MasterVolume.Value;
            stream.ProcessAllSamples(a => a * volume);
        }
    }
}
