using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCL.DTO
{

    public class ResponseDTO<T>
    {
        public ResponseStatus Status { get; set; } = ResponseStatus.Success;
        public List<T> List { get; set; }
        public T Data { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<MessageDTO> Messages { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Value { get; set; }
        /// <summary>
        /// Used to hold JSON string directly
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string JSONContent { get; set; }
        /// <summary>
        /// Concatenated Messages in the form of "Message (Code)"
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage
        {
            get
            {
                if (Messages != null && Messages.Count > 0)
                    return string.Join("::", Messages.Select(s => $"{s.Message} ({s.Code})"));
                return null;
            }
        }
    }
    public class MessageDTO
    {
        public MessageDTO() { }

        public MessageDTO(MessageCode code, string message, string field)
        {
            Code = code;
            Message = message;
            Field = field;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MessageCode Code { get; set; }     // required , MaxlengthExceed....
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        public string Field { get; set; }          //FieldName, like ContactID,Name, 

        public static implicit operator List<object>(MessageDTO v)
        {
            throw new NotImplementedException();
        }
    }

    public class APIResponse
    {
        public ResponseHeader responseHeader { get; set; }
        public object content { get; set; }

        public APIResponse()
        {
        }
        public APIResponse(object value)
        {
            this.content = value;
        }
    }
    public class ResponseHeader
    {
        //time stamp in response header
        public System.DateTime timestamp { get; set; }
    }
}
