using FubuMVC.Core.UI.Navigation;
using NUnit.Framework;
using FubuTestingSupport;

namespace FubuMVC.Tests.UI.Navigation
{
    [TestFixture]
    public class MenuChainTester
    {
        [Test]
        public void find_by_key_in_deep_structure()
        {
            var node1 = MenuNode.ForCreatorOf(FakeKeys.Key1, typeof(Address));
            var node2 = MenuNode.ForCreatorOf(FakeKeys.Key2, typeof(Address));
            var node3 = MenuNode.ForCreatorOf(FakeKeys.Key3, typeof(Address));
            var node4 = MenuNode.ForCreatorOf(FakeKeys.Key4, typeof(Address));
            var node5 = MenuNode.ForCreatorOf(FakeKeys.Key5, typeof(Address));
            var node6 = MenuNode.ForCreatorOf(FakeKeys.Key6, typeof(Address));
            var node7 = MenuNode.ForCreatorOf(FakeKeys.Key7, typeof(Address));
            var node8 = MenuNode.ForCreatorOf(FakeKeys.Key8, typeof(Address));

            node1.Children.AddToEnd(node2);
            node1.Children.AddToEnd(node3);

            node2.Children.AddToEnd(node4);
            node4.Children.AddToEnd(node5);

            node3.Children.AddToEnd(node6);
            node3.Children.AddToEnd(node7);
            node3.Children.AddToEnd(node8);

            var node9 = new MenuNode(FakeKeys.Key9);
            var node10 = new MenuNode(FakeKeys.Key10);

            var chain = new MenuChain(FakeKeys.Chain1);
            chain.AddToEnd(node1);

            chain.FindByKey(FakeKeys.Key1).ShouldBeTheSameAs(node1);
            chain.FindByKey(FakeKeys.Key2).ShouldBeTheSameAs(node2);
            chain.FindByKey(FakeKeys.Key3).ShouldBeTheSameAs(node3);
            chain.FindByKey(FakeKeys.Key4).ShouldBeTheSameAs(node4);
            chain.FindByKey(FakeKeys.Key5).ShouldBeTheSameAs(node5);
            chain.FindByKey(FakeKeys.Key6).ShouldBeTheSameAs(node6);
            chain.FindByKey(FakeKeys.Key7).ShouldBeTheSameAs(node7);

            chain.FindByKey(FakeKeys.Key9).ShouldBeNull();

            chain.AddToEnd(node9);
            chain.AddToEnd(node10);

            chain.FindByKey(FakeKeys.Key9).ShouldBeTheSameAs(node9);
            chain.FindByKey(FakeKeys.Key10).ShouldBeTheSameAs(node10);
        }

        [Test]
        public void all_nodes_of_deep_structure()
        {
            var node1 = MenuNode.ForCreatorOf(FakeKeys.Key1, typeof(Address));
            var node2 = MenuNode.ForCreatorOf(FakeKeys.Key2, typeof(Address));
            var node3 = MenuNode.ForCreatorOf(FakeKeys.Key3, typeof(Address));
            var node4 = MenuNode.ForCreatorOf(FakeKeys.Key4, typeof(Address));
            var node5 = MenuNode.ForCreatorOf(FakeKeys.Key5, typeof(Address));
            var node6 = MenuNode.ForCreatorOf(FakeKeys.Key6, typeof(Address));
            var node7 = MenuNode.ForCreatorOf(FakeKeys.Key7, typeof(Address));
            var node8 = MenuNode.ForCreatorOf(FakeKeys.Key8, typeof(Address));

            node1.Children.AddToEnd(node2);
            node1.Children.AddToEnd(node3);

            node2.Children.AddToEnd(node4);
            node4.Children.AddToEnd(node5);

            node3.Children.AddToEnd(node6);
            node3.Children.AddToEnd(node7);
            node3.Children.AddToEnd(node8);

            var node9 = new MenuNode(FakeKeys.Key9);
            var node10 = new MenuNode(FakeKeys.Key10);

            var chain = new MenuChain(FakeKeys.Chain1);
            chain.AddToEnd(node1);

            chain.AddToEnd(node9);
            chain.AddToEnd(node10);

            chain.AllNodes().ShouldHaveTheSameElementsAs(node1, node2, node4, node5, node3, node6, node7, node8, node9, node10);
        }
    }
}