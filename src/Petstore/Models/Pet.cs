using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Petstore.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    // [SwaggerSchemaFilter(typeof(PetSchemaFilter))]
    [SwaggerSchemaFilter(typeof(PetSchemaByBuilderFilter))]
    public partial class Pet : IEquatable<Pet>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets PhotoUrls
        /// </summary>
        [Required]
        public List<string> PhotoUrls { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// pet status in the store
        /// </summary>
        /// <value>pet status in the store</value>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum AvailableEnum for available
            /// </summary>
            [EnumMember(Value = "available")] AvailableEnum = 1,

            /// <summary>
            /// Enum PendingEnum for pending
            /// </summary>
            [EnumMember(Value = "pending")] PendingEnum = 2,

            /// <summary>
            /// Enum SoldEnum for sold
            /// </summary>
            [EnumMember(Value = "sold")] SoldEnum = 3
        }

        /// <summary>
        /// pet status in the store
        /// </summary>
        /// <value>pet status in the store</value>
        public StatusEnum? Status { get; set; }

        #region IEquatable

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Pet {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PhotoUrls: ").Append(PhotoUrls).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Pet) obj);
        }

        /// <summary>
        /// Returns true if Pet instances are equal
        /// </summary>
        /// <param name="other">Instance of Pet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Pet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Category == other.Category ||
                    Category != null &&
                    Category.Equals(other.Category)
                ) &&
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) &&
                (
                    PhotoUrls == other.PhotoUrls ||
                    PhotoUrls != null &&
                    PhotoUrls.SequenceEqual(other.PhotoUrls)
                ) &&
                (
                    Tags == other.Tags ||
                    Tags != null &&
                    Tags.SequenceEqual(other.Tags)
                ) &&
                (
                    Status == other.Status ||
                    Status != null &&
                    Status.Equals(other.Status)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Category != null)
                    hashCode = hashCode * 59 + Category.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (PhotoUrls != null)
                    hashCode = hashCode * 59 + PhotoUrls.GetHashCode();
                if (Tags != null)
                    hashCode = hashCode * 59 + Tags.GetHashCode();
                if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                return hashCode;
            }
        }

        #endregion

        #region Operators

#pragma warning disable 1591

        public static bool operator ==(Pet left, Pet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591

        #endregion Operators
    }
}