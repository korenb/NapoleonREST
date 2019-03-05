using System;
using Xunit;
using NapoleonNotes.Mapper;

namespace NapoleonNotes.Tests
{
    public class AutomapperTests
    {
        public AutomapperTests()
        {
            AutoMapper.Mapper.Initialize(cfg =>
                cfg.AddProfile<NoteProfile>());
        }

        [Fact]
        public void ValidateConfiguration()
        {
            AutoMapper.Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
