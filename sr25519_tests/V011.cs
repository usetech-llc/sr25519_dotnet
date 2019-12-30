using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schnorrkel;
using System;

namespace sr25519_tests
{
    [TestClass]
    public class V011
    {
        [TestMethod]
        public void Ok()
        {
            int MAX_METHOD_BYTES_SZ = 2048;

            // Version 0.1.1
            var signaturePayloadBytes = new byte[MAX_METHOD_BYTES_SZ];
            var rnd = new Random();
            rnd.NextBytes(signaturePayloadBytes);
            long payloadLength = MAX_METHOD_BYTES_SZ;

            byte[] signerPublicKey = new byte[] { 214, 120, 179, 224, 12, 66, 56, 136, 139, 191, 8, 219, 190, 29, 125, 231, 124, 63, 28, 161, 252, 113, 165, 162, 131, 119, 15, 6, 247, 205, 18, 5 };
            byte[] secretKeyVec = new byte[] { 168, 16, 86, 215, 19, 175, 31, 241, 123, 89, 158, 96, 210, 135, 149, 46, 137, 48, 27, 82, 8, 50, 74, 5, 41, 182, 45, 199, 54, 156, 116, 93, 239, 201, 200, 221, 103, 183, 197, 155, 32, 27, 193, 100, 22, 58, 137, 120, 212, 0, 16, 194, 39, 67, 219, 20, 42, 71, 242, 224, 100, 72, 13, 75 };

            var message = signaturePayloadBytes.AsMemory().Slice(0, (int)payloadLength).ToArray();
            var sig2 = Sr25519v011.SignSimple(signerPublicKey, secretKeyVec, message);

            Assert.IsTrue(Sr25519v011.Verify(sig2, signerPublicKey, message));

            // modify message
            message[0] = 0;
            Assert.IsFalse(Sr25519v011.Verify(sig2, signerPublicKey, message));
        }
    }
}
