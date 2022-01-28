using System;
using Autofac;
using Hangfire;

namespace Web.UI.Injection.Hangfire
{
    //see: https://github.com/BredStik/HangFire.Windsor/
    public class WindsorJobActivator : JobActivator
    {
        private readonly IContainer _kernel;

        /// <summary>
        /// Initializes new instance of WindsorJobActivator with a Windsor Kernel
        /// </summary>
        /// <param name="kernel">Kernel that will be used to create instance
        /// of classes during job activation process.</param>
        public WindsorJobActivator(IContainer kernel)
        {
            if (kernel == null) throw new ArgumentNullException("kernel");

            _kernel = kernel;
        }

        /// <summary>
        /// Activates a job of a given type using the Windsor Kernel
        /// </summary>
        /// <param name="jobType">Type of job to activate</param>
        /// <returns></returns>
        public override object ActivateJob(Type jobType)
        {
            return _kernel.Resolve(jobType);
        }
    }
}