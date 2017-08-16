using System.Collections;
using System.Collections.Generic;
using Amazon.Runtime;

namespace WBPA.Amazon
{
    /// <summary>
    /// An abstract class for establishing concrete implementations of the <see cref="ConstantClass"/>.
    /// </summary>
    /// <typeparam name="T">The type of the constant representation.</typeparam>
    /// <seealso cref="IList{ConstantClass}" />
    public abstract class ConstantClassCollection<T> : IList<ConstantClass> where T : ConstantClass
    {
        private readonly List<ConstantClass> _wrapper = new List<ConstantClass>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantClassCollection{T}"/> class.
        /// </summary>
        protected ConstantClassCollection()
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="ConstantClass"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The <see cref="ConstantClass"/> at the specified index.</returns>
        public ConstantClass this[int index]
        {
            get => _wrapper[index];
            set => _wrapper[index] = value;
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="ConstantClassCollection{T}" />.
        /// </summary>
        /// <value>The count.</value>
        public int Count => _wrapper.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="ConstantClassCollection{T}" /> is read-only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an item to the <see cref="ConstantClassCollection{T}" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="ConstantClassCollection{T}" />.</param>
        void ICollection<ConstantClass>.Add(ConstantClass item)
        {
            _wrapper.Add(item);
        }

        /// <summary>
        /// Adds the specified item to the <see cref="ConstantClassCollection{T}" />.
        /// </summary>
        /// <param name="cc">The <see cref="ConstantClass"/> to add to the <see cref="ConstantClassCollection{T}" />.</param>
        public void Add(T cc)
        {
            _wrapper.Add(cc);
        }

        /// <summary>
        /// Removes all items from the <see cref="ConstantClassCollection{T}" />.
        /// </summary>
        public void Clear()
        {
            _wrapper.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="ConstantClassCollection{T}" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="ConstantClassCollection{T}" />.</param>
        /// <returns>true if <paramref name="item" /> is found in the <see cref="ConstantClassCollection{T}" />; otherwise, false.</returns>
        public bool Contains(ConstantClass item)
        {
            return _wrapper.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the <see cref="ConstantClassCollection{T}" /> to an <see cref="Array" />, starting at a particular <see cref="Array" /> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array" /> that is the destination of the elements copied from <see cref="ConstantClassCollection{T}" />. The <see cref="Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        void ICollection<ConstantClass>.CopyTo(ConstantClass[] array, int arrayIndex)
        {
            _wrapper.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="ConstantClassCollection{T}" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="ConstantClassCollection{T}" />.</param>
        /// <returns>true if <paramref name="item" /> was successfully removed from the <see cref="ConstantClassCollection{T}" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="ConstantClassCollection{T}" />.</returns>
        public bool Remove(ConstantClass item)
        {
            return _wrapper.Remove(item);
        }


        /// <summary>
        /// Determines the index of a specific item in the <see cref="ConstantClassCollection{T}" />.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="ConstantClassCollection{T}" />.</param>
        /// <returns>The index of <paramref name="item" /> if found in the list; otherwise, -1.</returns>
        public int IndexOf(ConstantClass item)
        {
            return _wrapper.IndexOf(item);
        }

        /// <summary>
        /// Inserts an item to the <see cref="ConstantClassCollection{T}" /> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="ConstantClassCollection{T}" />.</param>
        void IList<ConstantClass>.Insert(int index, ConstantClass item)
        {
            _wrapper.Insert(index, item);
        }

        /// <summary>
        /// Removes the <see cref="ConstantClassCollection{T}" /> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            _wrapper.RemoveAt(index);
        }




        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<ConstantClass> GetEnumerator()
        {
            return _wrapper.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _wrapper.GetEnumerator();
        }
    }
}