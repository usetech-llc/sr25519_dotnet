namespace sr25519_tests
{
    using Xunit;
    using Xunit.Abstractions;
    using System.Text;
    using System.IO;
    using System;
    using Schnorrkel;

    public class V011
    {
        private readonly ITestOutputHelper output;

        public V011(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Ok()
        {
            const long payloadSize = 20;

            // Version 0.1.1
            var signaturePayloadBytes = new byte[payloadSize];
            var rnd = new Random();
            rnd.NextBytes(signaturePayloadBytes);

            byte[] signerPublicKey = new byte[] { 214, 120, 179, 224, 12, 66, 56, 136, 139, 191, 8, 219, 190, 29, 125, 231, 124, 63, 28, 161, 252, 113, 165, 162, 131, 119, 15, 6, 247, 205, 18, 5 };
            byte[] secretKeyVec = new byte[] { 168, 16, 86, 215, 19, 175, 31, 241, 123, 89, 158, 96, 210, 135, 149, 46, 137, 48, 27, 82, 8, 50, 74, 5, 41, 182, 45, 199, 54, 156, 116, 93, 239, 201, 200, 221, 103, 183, 197, 155, 32, 27, 193, 100, 22, 58, 137, 120, 212, 0, 16, 194, 39, 67, 219, 20, 42, 71, 242, 224, 100, 72, 13, 75 };

            var message = signaturePayloadBytes.AsMemory().Slice(0, (int)payloadSize).ToArray();
            var sig2 = Sr25519v011.SignSimple(signerPublicKey, secretKeyVec, message);

            Console.Write("Message: 0x");
            for (var i=0; i<payloadSize; i++) {
                Console.Write($"{signaturePayloadBytes[i]:X2}");
            }
            Console.WriteLine("");

            Console.Write("Signature: 0x");
            for (var i=0; i<sig2.Length; i++) {
                Console.Write($"{sig2[i]:X2}");
            }
            Console.WriteLine("");

            Assert.True(Sr25519v011.Verify(sig2, signerPublicKey, message));

            // modify message
            message[0] = 0;
            Assert.False(Sr25519v011.Verify(sig2, signerPublicKey, message));
        }
    }
}
