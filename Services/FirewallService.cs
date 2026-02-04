using System;
using System.Collections.Generic;
using System.Linq;
using MagicOnion;
using MagicOnion.Server;
using IFirewallService = global::LibFirewall.Shared.Services.IFirewallService;
using LocalTypes = global::LibFirewall;
using SharedTypes = global::LibFirewall.Shared;

namespace FirewallConsoleApp.Services
{
    public class FirewallService : ServiceBase<IFirewallService>, IFirewallService
    {
        public UnaryResult<List<SharedTypes.FirewallInboundRule>> GetInboundRulesAsync()
        {
            try
            {
                var rules = LocalTypes.Firewall.GetInboundRules().ToList();
                foreach (var rule in rules)
                {
                    rule.Name = ResourceResolver.ResolveString(rule.Name);
                    rule.Description = ResourceResolver.ResolveString(rule.Description);
                    rule.Grouping = ResourceResolver.ResolveString(rule.Grouping);
                }
                return UnaryResult.FromResult(rules);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error fetching inbound rules: {ex.Message}"));
            }
        }

        public UnaryResult<bool> AddInboundRuleAsync(SharedTypes.FirewallInboundRule rule)
        {
            try
            {
                LocalTypes.Firewall.AddInboundRule(rule);
                return UnaryResult.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error adding inbound rule: {ex.Message}"));
            }
        }

        public UnaryResult<bool> UpdateInboundRuleAsync(SharedTypes.FirewallInboundRule rule)
        {
            try
            {
                LocalTypes.Firewall.UpdateInboundRule(rule);
                return UnaryResult.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error updating inbound rule: {ex.Message}"));
            }
        }

        public UnaryResult<bool> DeleteInboundRuleAsync(string name)
        {
            try
            {
                LocalTypes.Firewall.DeleteRule(name);
                return UnaryResult.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error deleting inbound rule: {ex.Message}"));
            }
        }

        public UnaryResult<List<SharedTypes.FirewallOutboundRule>> GetOutboundRulesAsync()
        {
            try
            {
                var rules = LocalTypes.Firewall.GetOutboundRules().ToList();
                foreach (var rule in rules)
                {
                    rule.Name = ResourceResolver.ResolveString(rule.Name);
                    rule.Description = ResourceResolver.ResolveString(rule.Description);
                    rule.Grouping = ResourceResolver.ResolveString(rule.Grouping);
                }
                return UnaryResult.FromResult(rules);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error fetching outbound rules: {ex.Message}"));
            }
        }

        public UnaryResult<bool> AddOutboundRuleAsync(SharedTypes.FirewallOutboundRule rule)
        {
            try
            {
                LocalTypes.Firewall.AddOutboundRule(rule);
                return UnaryResult.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error adding outbound rule: {ex.Message}"));
            }
        }

        public UnaryResult<bool> UpdateOutboundRuleAsync(SharedTypes.FirewallOutboundRule rule)
        {
            try
            {
                LocalTypes.Firewall.UpdateOutboundRule(rule);
                return UnaryResult.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error updating outbound rule: {ex.Message}"));
            }
        }

        public UnaryResult<bool> DeleteOutboundRuleAsync(string name)
        {
            try
            {
                LocalTypes.Firewall.DeleteRule(name);
                return UnaryResult.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error deleting outbound rule: {ex.Message}"));
            }
        }

        public UnaryResult<List<SharedTypes.FirewallConnectionRule>> GetConnectionRulesAsync()
        {
            try
            {
                var rules = LocalTypes.Firewall.GetConnectionRules().ToList();
                foreach (var rule in rules)
                {
                    rule.Name = ResourceResolver.ResolveString(rule.Name);
                    rule.Description = ResourceResolver.ResolveString(rule.Description);
                }
                return UnaryResult.FromResult(rules);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error fetching connection rules: {ex.Message}"));
            }
        }

        public UnaryResult<bool> AddConnectionRuleAsync(SharedTypes.FirewallConnectionRule rule)
        {
            try
            {
                LocalTypes.Firewall.AddConnectionRule(rule);
                return UnaryResult.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error adding connection rule: {ex.Message}"));
            }
        }

        public UnaryResult<bool> UpdateConnectionRuleAsync(SharedTypes.FirewallConnectionRule rule)
        {
            try
            {
                LocalTypes.Firewall.UpdateConnectionRule(rule);
                return UnaryResult.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error updating connection rule: {ex.Message}"));
            }
        }

        public UnaryResult<bool> DeleteConnectionRuleAsync(string name)
        {
            try
            {
                LocalTypes.Firewall.DeleteConnectionRule(name);
                return UnaryResult.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Grpc.Core.RpcException(new Grpc.Core.Status(Grpc.Core.StatusCode.Internal, $"Error deleting connection rule: {ex.Message}"));
            }
        }
    }
}
