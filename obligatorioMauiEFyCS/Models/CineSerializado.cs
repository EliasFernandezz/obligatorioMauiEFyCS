using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickType
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CineSerializado
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("media_type")]
        public MediaType MediaType { get; set; }

        [JsonProperty("original_language")]
        public OriginalLanguage OriginalLanguage { get; set; }

        [JsonProperty("genre_ids")]
        public long[] GenreIds { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("release_date")]
        public DateTimeOffset ReleaseDate { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }
    }

    public enum MediaType { Movie };

    public enum OriginalLanguage { En, Zh };

    public partial class CineSerializado
    {
        public static CineSerializado FromJson(string json) => JsonConvert.DeserializeObject<CineSerializado>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CineSerializado self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                MediaTypeConverter.Singleton,
                OriginalLanguageConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class MediaTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MediaType) || t == typeof(MediaType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "movie")
            {
                return MediaType.Movie;
            }
            throw new Exception("Cannot unmarshal type MediaType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MediaType)untypedValue;
            if (value == MediaType.Movie)
            {
                serializer.Serialize(writer, "movie");
                return;
            }
            throw new Exception("Cannot marshal type MediaType");
        }

        public static readonly MediaTypeConverter Singleton = new MediaTypeConverter();
    }

    internal class OriginalLanguageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OriginalLanguage) || t == typeof(OriginalLanguage?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "en":
                    return OriginalLanguage.En;
                case "zh":
                    return OriginalLanguage.Zh;
            }
            throw new Exception("Cannot unmarshal type OriginalLanguage");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OriginalLanguage)untypedValue;
            switch (value)
            {
                case OriginalLanguage.En:
                    serializer.Serialize(writer, "en");
                    return;
                case OriginalLanguage.Zh:
                    serializer.Serialize(writer, "zh");
                    return;
            }
            throw new Exception("Cannot marshal type OriginalLanguage");
        }

        public static readonly OriginalLanguageConverter Singleton = new OriginalLanguageConverter();
    }
}

