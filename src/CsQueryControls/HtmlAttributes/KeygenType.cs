namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies the security algorithm of the key
    /// </summary>
    public enum KeygenType {
        /// <summary>
        ///     Default. Specifies an RSA security algorithm. The user may be given a choice of RSA key strengths
        /// </summary>
        Rsa,
        /// <summary>
        ///     Specifies a DSA security algorithm. The user may be given a choice of DSA key sizes
        /// </summary>
        Dsa,
        /// <summary>
        ///     Specifies an EC security algorithm. The user may be given a choice of EC key strengths
        /// </summary>
        Ec
    }
}