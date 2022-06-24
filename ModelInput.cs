using System.ComponentModel.DataAnnotations;
using Microsoft.ML.Data;

namespace MLModel_Api;

public partial class MlModel
{
    /// <summary>
    /// model input class for MLModel.
    /// </summary>
    public class ModelInput
    {
        [ColumnName(@"Entity"), Required] public string Entity { get; set; }

        [ColumnName(@"Code"), Required] public string Code { get; set; }

        [ColumnName(@"Year"), Required] public float Year { get; set; }
    }
}