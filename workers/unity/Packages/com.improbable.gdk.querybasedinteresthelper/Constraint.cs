using System.Collections.Generic;
using Improbable.Gdk.Core;

namespace Improbable.Gdk.QueryBasedInterest
{
    /// <summary>
    ///     Utility class to help define constraints for Interest queries.
    /// </summary>
    public class Constraint
    {
        private ComponentInterest.QueryConstraint constraint;

        private Constraint(ComponentInterest.QueryConstraint constraint)
        {
            this.constraint = constraint;
        }

        private static ComponentInterest.QueryConstraint Default()
        {
            return new ComponentInterest.QueryConstraint
            {
                AndConstraint = new List<ComponentInterest.QueryConstraint>(),
                OrConstraint = new List<ComponentInterest.QueryConstraint>()
            };
        }

        /// <summary>
        ///     Creates a Constraint object with a Sphere constraint.
        /// </summary>
        /// <param name="radius">
        ///     Radius of the Sphere constraint.
        /// </param>
        /// <param name="center">
        ///     Center of the Sphere constraint.
        /// </param>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint Sphere(double radius, Coordinates center)
        {
            var constraint = Default();
            constraint.SphereConstraint = new ComponentInterest.SphereConstraint
            {
                Center = center,
                Radius = radius
            };
            return new Constraint(constraint);
        }

        /// <summary>
        ///     Creates a Constraint object with a Sphere constraint.
        /// </summary>
        /// <param name="radius">
        ///     Radius of the Sphere constraint.
        /// </param>
        /// <param name="centerX">
        ///     X coordinate of the center of the Sphere constraint.
        /// </param>
        /// <param name="centerY">
        ///     Y coordinate of the center of the Sphere constraint.
        /// </param>
        /// <param name="centerZ">
        ///     Z coordinate of the center of the Sphere constraint.
        /// </param>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint Sphere(
            double radius,
            double centerX,
            double centerY,
            double centerZ)
        {
            return Sphere(radius, new Coordinates(centerX, centerY, centerZ));
        }

        /// <summary>
        ///     Creates a Constraint object with a Cylinder constraint.
        /// </summary>
        /// <param name="radius">
        ///     Radius of the Cylinder constraint.
        /// </param>
        /// <param name="center">
        ///     Center of the Cylinder constraint.
        /// </param>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint Cylinder(double radius, Coordinates center)
        {
            var constraint = Default();
            constraint.CylinderConstraint = new ComponentInterest.CylinderConstraint()
            {
                Center = center,
                Radius = radius
            };
            return new Constraint(constraint);
        }

        /// <summary>
        ///     Creates a Constraint object with a Cylinder constraint.
        /// </summary>
        /// <param name="radius">
        ///     Radius of the Cylinder constraint.
        /// </param>
        /// <param name="centerX">
        ///     X coordinate of the center of the Cylinder constraint.
        /// </param>
        /// <param name="centerY">
        ///     Y coordinate of the center of the Cylinder constraint.
        /// </param>
        /// <param name="centerZ">
        ///     Z coordinate of the center of the Cylinder constraint.
        /// </param>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint Cylinder(
            double radius,
            double centerX,
            double centerY,
            double centerZ)
        {
            return Cylinder(radius, new Coordinates(centerX, centerY, centerZ));
        }

        /// <summary>
        ///     Creates a Constraint object with a Box constraint.
        /// </summary>
        /// <param name="xWidth">
        ///     Width of Box constraint in the X-axis.
        /// </param>
        /// <param name="yHeight">
        ///     Height of Box constraint in the Y-axis.
        /// </param>
        /// <param name="zDepth">
        ///     Depth of Box constraint in the Z-axis.
        /// </param>
        /// <param name="center">
        ///     Center of the Box constraint.
        /// </param>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint Box(
            double xWidth,
            double yHeight,
            double zDepth,
            Coordinates center)
        {
            var constraint = Default();
            constraint.BoxConstraint = new ComponentInterest.BoxConstraint
            {
                Center = center,
                EdgeLength = new EdgeLength(xWidth, yHeight, zDepth)
            };
            return new Constraint(constraint);
        }

        /// <summary>
        ///     Creates a Constraint object with a Box constraint.
        /// </summary>
        /// <param name="xWidth">
        ///     Width of Box constraint in the X-axis.
        /// </param>
        /// <param name="yHeight">
        ///     Height of Box constraint in the Y-axis.
        /// </param>
        /// <param name="zDepth">
        ///     Depth of Box constraint in the Z-axis.
        /// </param>
        /// <param name="centerX">
        ///     X coordinate of the center of the Box constraint.
        /// </param>
        /// <param name="centerY">
        ///     Y coordinate of the center of the Box constraint.
        /// </param>
        /// <param name="centerZ">
        ///     Z coordinate of the center of the Box constraint.
        /// </param>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint Box(
            double xWidth,
            double yHeight,
            double zDepth,
            double centerX,
            double centerY,
            double centerZ)
        {
            return Box(xWidth, yHeight, zDepth, new Coordinates(centerX, centerY, centerZ));
        }

        /// <summary>
        ///     Creates a Constraint object with a RelativeSphere constraint.
        /// </summary>
        /// <param name="radius">
        ///     Radius of the RelativeSphere constraint.
        /// </param>
        /// <remarks>
        ///     This constraint defines a sphere relative to the position of the entity.
        /// </remarks>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint RelativeSphere(double radius)
        {
            var constraint = Default();
            constraint.RelativeSphereConstraint = new ComponentInterest.RelativeSphereConstraint
            {
                Radius = radius
            };
            return new Constraint(constraint);
        }

        /// <summary>
        ///     Creates a Constraint object with a RelativeCylinder constraint.
        /// </summary>
        /// <param name="radius">
        ///     Radius of the cylinder constraint.
        /// </param>
        /// <remarks>
        ///     This constraint defines a cylinder relative to the position of the entity.
        /// </remarks>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint RelativeCylinder(double radius)
        {
            var constraint = Default();
            constraint.RelativeCylinderConstraint = new ComponentInterest.RelativeCylinderConstraint
            {
                Radius = radius
            };
            return new Constraint(constraint);
        }

        /// <summary>
        ///     Creates a Constraint object with a RelativeBox constraint.
        /// </summary>
        /// <param name="xWidth">
        ///     Width of box constraint in the X-axis.
        /// </param>
        /// <param name="yHeight">
        ///     Height of box constraint in the Y-axis.
        /// </param>
        /// <param name="zDepth">
        ///     Depth of box constraint in the Z-axis.
        /// </param>
        /// <remarks>
        ///     This constraint defines a box relative to the position of the entity.
        /// </remarks>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint RelativeBox(double xWidth, double yHeight, double zDepth)
        {
            var constraint = Default();
            constraint.RelativeBoxConstraint = new ComponentInterest.RelativeBoxConstraint
            {
                EdgeLength = new EdgeLength(xWidth, yHeight, zDepth)
            };
            return new Constraint(constraint);
        }

        /// <summary>
        ///     Creates a Constraint object with an EntityId constraint.
        /// </summary>
        /// <param name="entityId">
        ///     EntityId of the .
        /// </param>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint EntityId(EntityId entityId)
        {
            var constraint = Default();
            constraint.EntityIdConstraint = entityId.Id;
            return new Constraint(constraint);
        }

        /// <summary>
        ///     Creates a Constraint object with an EntityId constraint.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the component to constrain.
        /// </typeparam>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint Component<T>() where T : ISpatialComponentData
        {
            var constraint = Default();
            constraint.ComponentConstraint = Dynamic.GetComponentId<T>();
            return new Constraint(constraint);
        }

        /// <summary>
        ///     Creates a Constraint object with a Component constraint.
        /// </summary>
        /// <param name="componentId">
        ///     ID of the component to constrain.
        /// </param>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint Component(uint componentId)
        {
            var constraint = Default();
            constraint.ComponentConstraint = componentId;
            return new Constraint(constraint);
        }

        /// <summary>
        ///     Creates a Constraint object with an And constraint.
        /// </summary>
        /// <param name="constraint">
        ///     First constraint in the list of conjunctions.
        /// </param>
        /// <param name="constraints">
        ///     Further constraints for the list of conjunctions.
        /// </param>
        /// <remarks>
        ///     At least one constraint must be provided to create an "All" QueryConstraint.
        /// </remarks>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint All(Constraint constraint, params Constraint[] constraints)
        {
            return new Constraint(new ComponentInterest.QueryConstraint
            {
                AndConstraint = ConstraintParamsToList(constraint, constraints),
                OrConstraint = new List<ComponentInterest.QueryConstraint>()
            });
        }

        /// <summary>
        ///     Creates a Constraint object with an Or constraint.
        /// </summary>
        /// <param name="constraint">
        ///     First constraint in the list of disjunctions.
        /// </param>
        /// <param name="constraints">
        ///     Further constraints for the list of disjunctions.
        /// </param>
        /// <remarks>
        ///     At least one constraint must be provided to create an "Any" QueryConstraint.
        /// </remarks>
        /// <returns>
        ///     A Constraint object.
        /// </returns>
        public static Constraint Any(Constraint constraint, params Constraint[] constraints)
        {
            return new Constraint(new ComponentInterest.QueryConstraint
            {
                AndConstraint = new List<ComponentInterest.QueryConstraint>(),
                OrConstraint = ConstraintParamsToList(constraint, constraints)
            });
        }

        /// <summary>
        ///     Returns a QueryConstraint object from a Constraint.
        /// </summary>
        /// <returns>
        ///     A QueryConstraint object.
        /// </returns>
        public ComponentInterest.QueryConstraint AsQueryConstraint()
        {
            return constraint;
        }

        private static List<ComponentInterest.QueryConstraint> ConstraintParamsToList(Constraint constraint,
            params Constraint[] constraints)
        {
            var output = new List<ComponentInterest.QueryConstraint>(constraints.Length + 1)
            {
                constraint.constraint
            };

            foreach (var constraintParam in constraints)
            {
                output.Add(constraintParam.constraint);
            }

            return output;
        }
    }
}
