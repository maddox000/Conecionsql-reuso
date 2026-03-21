using System;
using System.IO;
using ConexionSql.Models.Materiales;

namespace ConexionSql.Utilidades.Afmr
{
    public static class AfmrIbMatHelper
    {
        public static void Ejecutar(IbMat material)
        {
            if (material == null) return;

            var rutaCarpeta = @"C:\Logs";
            var rutaArchivo = Path.Combine(rutaCarpeta, "material_debug.txt");

            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            string texto = $@"
===== AFMR_IB_MAT =====
FECHA: {DateTime.Now:yyyy-MM-dd HH:mm:ss}

ID: {material.IB_MAT_ID}
PR: {material.IB_MAT_PR?.ToString() ?? "NULL"}
DEN: {material.IB_MAT_DEN ?? "NULL"}
MTI_ID: {material.IB_MAT_MTI_ID?.ToString() ?? "NULL"}
MTI_DEN: {material.IB_MAT_MTI_DEN ?? "NULL"}
MGR_ID: {material.IB_MAT_MGR_ID?.ToString() ?? "NULL"}
MGR_DEN: {material.IB_MAT_MGR_DEN ?? "NULL"}
VEN: {material.IB_MAT_VEN?.ToString() ?? "NULL"}
REU_CANT: {material.IB_MAT_REU_CANT?.ToString() ?? "NULL"}
CON_UNID: {material.IB_MAT_CON_UNID?.ToString() ?? "NULL"}

CON_ACT: {material.IB_MAT_CON_ACT}
OCU: {material.IB_MAT_OCU}

PRI_OPC: {material.IB_MAT_PRI_OPC}
CON_OPC: {material.IB_MAT_CON_OPC}
VOP_OPC: {material.IB_MAT_VOP_OPC}
VOP_OPC_FORM: {material.IB_MAT_VOP_OPC_FORM}
VOP_ACO_OPC_FORM: {material.IB_MAT_VOP_ACO_OPC_FORM}
REU_OPC: {material.IB_MAT_REU_OPC}
REU_OPC_CANT: {material.IB_MAT_REU_OPC_CANT}


ALT: {material.IB_MAT_ALT?.ToString() ?? "NULL"}
ANC: {material.IB_MAT_ANC?.ToString() ?? "NULL"}
PRO: {material.IB_MAT_PRO?.ToString() ?? "NULL"}
VOL: {material.IB_MAT_VOL?.ToString() ?? "NULL"}

IMG_1: {material.IB_MAT_IMG_1 ?? "NULL"}
IMG_2: {material.IB_MAT_IMG_2 ?? "NULL"}
IMG_3: {material.IB_MAT_IMG_3 ?? "NULL"}
IMG_4: {material.IB_MAT_IMG_4 ?? "NULL"}

LMAT: {material.IB_MAT_LMAT?.ToString() ?? "NULL"}
CANT_MULT: {material.IB_MAT_CANT_MULT?.ToString() ?? "NULL"}
UE: {material.IB_MAT_UE?.ToString() ?? "NULL"}

ETI_ID: {material.IB_MAT_ETI_ID?.ToString() ?? "NULL"}
ETI_DEN: {material.IB_MAT_ETI_DEN ?? "NULL"}
ETI_VENC: {material.IB_MAT_ETI_VENC?.ToString() ?? "NULL"}

PTE1_ID: {material.IB_MAT_PTE1_ID?.ToString() ?? "NULL"}
PTE1_DEN: {material.IB_MAT_PTE1_DEN ?? "NULL"}
PTE1_UBI_ID: {material.IB_MAT_PTE1_UBI_ID?.ToString() ?? "NULL"}
PTE1_UBI_DEN: {material.IB_MAT_PTE1_UBI_DEN ?? "NULL"}

PROC1_ID: {material.IB_MAT_PROC1_ID?.ToString() ?? "NULL"}
PROC1_DEN: {material.IB_MAT_PROC1_DEN ?? "NULL"}
PROC1_TCI_ID: {material.IB_MAT_PROC1_TCI_ID?.ToString() ?? "NULL"}
PROC1_TCI_DEN: {material.IB_MAT_PROC1_TCI_DEN ?? "NULL"}

PROC2_ID: {material.IB_MAT_PROC2_ID?.ToString() ?? "NULL"}
PROC2_DEN: {material.IB_MAT_PROC2_DEN ?? "NULL"}
PROC2_TCI_ID: {material.IB_MAT_PROC2_TCI_ID?.ToString() ?? "NULL"}
PROC2_TCI_DEN: {material.IB_MAT_PROC2_TCI_DEN ?? "NULL"}

TXT_1: {material.IB_MAT_TXT_1 ?? "NULL"}
TXT_2: {material.IB_MAT_TXT_2 ?? "NULL"}
TXT_3: {material.IB_MAT_TXT_3 ?? "NULL"}

NUM_1: {material.IB_MAT_NUM_1?.ToString() ?? "NULL"}
NUM_2: {material.IB_MAT_NUM_2?.ToString() ?? "NULL"}
NUM_3: {material.IB_MAT_NUM_3?.ToString() ?? "NULL"}

DAT_1: {material.IB_MAT_DAT_1?.ToString() ?? "NULL"}
DAT_2: {material.IB_MAT_DAT_2?.ToString() ?? "NULL"}
DAT_3: {material.IB_MAT_DAT_3?.ToString() ?? "NULL"}

MEM_1: {material.IB_MAT_MEM_1 ?? "NULL"}
MEN_2: {material.IB_MAT_MEN_2 ?? "NULL"}
MEN_3: {material.IB_MAT_MEN_3 ?? "NULL"}

BIT_1: {material.IB_MAT_BIT_1}
BIT_2: {material.IB_MAT_BIT_2}
BIT_3: {material.IB_MAT_BIT_3}

PMAT: {material.IB_MAT_PMAT?.ToString() ?? "NULL"}
STOCK_NFAR: {material.IB_MAT_STOCK_NFAR?.ToString() ?? "NULL"}

========================

";

            File.AppendAllText(rutaArchivo, texto + Environment.NewLine);
        }
    }
}