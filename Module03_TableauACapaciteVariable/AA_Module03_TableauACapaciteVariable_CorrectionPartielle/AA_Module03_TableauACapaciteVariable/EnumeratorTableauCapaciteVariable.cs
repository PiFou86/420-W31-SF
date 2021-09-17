using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AA_Module03_TableauACapaciteVariable
{
    public class EnumeratorTableauCapaciteVariable<TypeElement> : IEnumerator<TypeElement>
    {
        private int m_indiceCourante = 0;
        private TableauCapaciteVariable<TypeElement> m_tcv;
        private TypeElement m_current;

        internal EnumeratorTableauCapaciteVariable(TableauCapaciteVariable<TypeElement> p_tableauCapaciteVariable)
        {
            this.m_tcv = p_tableauCapaciteVariable;
        }

        public TypeElement Current
        {
            get
            {
                return this.m_current;
            }
        }

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
            ;
        }

        public bool MoveNext()
        {
            bool continuer = this.m_indiceCourante < this.m_tcv.Count;
            if (continuer)
            {
                this.m_current = this.m_tcv[this.m_indiceCourante];
                ++this.m_indiceCourante;
            }

            return continuer;
        }

        public void Reset()
        {
            this.m_indiceCourante = 0;
            this.m_current = default;
        }
    }
}
