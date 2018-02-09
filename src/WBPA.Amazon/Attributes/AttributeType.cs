namespace WBPA.Amazon.Attributes
{
    /// <summary>
    /// Attribute data types identify how the attribute values are handled by AWS.
    /// </summary>
    public enum AttributeType
    {
        /// <summary>
        /// Strings are Unicode with UTF-8 binary encoding.
        /// </summary>
        String = 0,
        /// <summary>
        /// Numbers are positive or negative integers or floating point numbers. 
        /// </summary>
        Number = 1,
        /// <summary>
        /// Binary type attributes can store any binary data, for example, compressed data, encrypted data, or images.
        /// </summary>
        Binary = 2
    }
}