using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Moq;
using MWork.Common.Sdk.WebApi.Extensions;
using MWork.Common.Sdk.WebApi.Helpers;
using Xunit;

namespace MWork.Common.WebApi.Tests
{
    public class ConfigurationExtensionsTests
    {
        [Fact]
        public void Not_A_Secret()
        {
            const string variable = "test";
            const string expected = variable;
            
            var actual = ConfigurationMock(variable).GetSecret(variable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Docker_Secret_File_Found_String()
        {
            const string secretFilePath = "/run/secrets/test";
            const string secretKey = "test";
            const string secretFileContent = "test";
            
            var fileManagerMock = new Mock<IFileManager>();
            fileManagerMock
                .Setup(x => x.FileExists(It.IsAny<string>()))
                .Returns(true);
            fileManagerMock
                .Setup(x => x.ReadAllText(It.IsAny<string>()))
                .Returns(secretFileContent);

            var actual = ConfigurationMock(secretFilePath).GetSecret(secretKey, fileManagerMock.Object);
            Assert.Equal(secretFileContent, actual);
        }
        
        [Fact]
        public void Docker_Secret_File_Found_Conversion_Fail()
        {
            const string secretFilePath = "/run/secrets/test";
            const string secretKey = "test";
            const string secretFileContent = "test";
            
            var fileManagerMock = new Mock<IFileManager>();
            fileManagerMock
                .Setup(x => x.FileExists(It.IsAny<string>()))
                .Returns(true);
            fileManagerMock
                .Setup(x => x.ReadAllText(It.IsAny<string>()))
                .Returns(secretFileContent);

            Assert.Throws<FormatException>(() => ConfigurationMock(secretFilePath).GetSecret<bool>(secretKey, fileManagerMock.Object));
        }
        
        [Fact]
        public void Docker_Secret_File_Found_Conversion_Success()
        {
            const string secretFilePath = "/run/secrets/test";
            const string secretKey = "test";
            const string secretFileContent = "true";
            const bool expected = true;
            
            var fileManagerMock = new Mock<IFileManager>();
            fileManagerMock
                .Setup(x => x.FileExists(It.IsAny<string>()))
                .Returns(true);
            fileManagerMock
                .Setup(x => x.ReadAllText(It.IsAny<string>()))
                .Returns(secretFileContent);

            var actual = ConfigurationMock(secretFilePath).GetSecret<bool>(secretKey, fileManagerMock.Object);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Docker_Secret_File_Not_Found_Exception()
        {
            const string secretFilePath = "/run/secrets/test";
            const string secretKey = "test";
            
            var fileManagerMock = new Mock<IFileManager>();
            fileManagerMock
                .Setup(x => x.FileExists(It.IsAny<string>()))
                .Returns(false);
            
            Assert.Throws<FileNotFoundException>(() => ConfigurationMock(secretFilePath).GetSecret(secretKey, fileManagerMock.Object));
        }

        private static IConfiguration ConfigurationMock(string configValue)
        {
            var configurationSectionMock = new Mock<IConfigurationSection>();
            configurationSectionMock
                .Setup(x => x.Value)
                .Returns(configValue);
            
            var configurationMock = new Mock<IConfiguration>();
            configurationMock
                .Setup(x => x.GetSection(It.IsAny<string>()))
                .Returns(configurationSectionMock.Object);

            return configurationMock.Object;
        }
    }
}